using ASC.Online.AuctionApp.Framework.Utility.Middleware;
using ASC.Online.AuctionApp.SessionSetup.Api.Controllers;
using ASC.Online.AuctionApp.SessionSetup.Business.Components;
using ASC.Online.AuctionApp.SessionSetup.Business.Components.Interface;
using ASC.Online.AuctionApp.SessionSetup.DataAccess.Contexts;
using ASC.Online.AuctionApp.SessionSetup.DataAccess.Contexts.Interfaces;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ASC.Online.AuctionApp.SessionSetup.Api
{
    /// <summary>
    /// Start up class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc().AddNewtonsoftJson();

            services.AddMvc().AddMvcOptions(
           o =>
           {
               o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
           }).AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddMvc(setupAction =>
            {
                var jsonOutputFormatter = setupAction.OutputFormatters
                    .OfType<NewtonsoftJsonOutputFormatter>().FirstOrDefault();
                // remove text/json as it isn't the approved media type
                // for working with JSON at API level
                if (jsonOutputFormatter != null &&
                jsonOutputFormatter.SupportedMediaTypes.Contains("text/json"))
                {
                    jsonOutputFormatter.SupportedMediaTypes.Remove("text/json");
                }
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var actionExecutingContext =
                        actionContext as Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext;
                    // if there are modelstate errors & all keys were correctly
                    // found/parsed we're dealing with validation errors
                    if (actionContext.ModelState.ErrorCount > 0
                        && actionExecutingContext?.ActionArguments.Count == actionContext.ActionDescriptor.Parameters.Count)
                    {
                        return new UnprocessableEntityObjectResult(actionContext.ModelState);
                    }
                    // if one of the keys wasn't correctly found / couldn't be parsed
                    // we're dealing with null/unparsable input
                    return new BadRequestObjectResult(actionContext.ModelState);
                };
            });
            var serviceProvider = GetVersionDescriptionProvider(services);
            var logger = serviceProvider.GetService<ILogger<SessionsController>>();
            services.AddSingleton(typeof(ILogger), logger);

            services.AddScoped<ISessionComponent, SessionComponent>();
            services.AddScoped<ISessionContext, SessionContext>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddCors(options =>
                        options.AddPolicy("AllowCors",
                                builderCORS =>
                                {
                                      builderCORS
                                        .WithOrigins("http://localhost:4200/")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                                 })
             );

            services.AddVersionedApiExplorer(setupAction =>
            {
                setupAction.GroupNameFormat = "'v'VV";
            });
            services.AddApiVersioning(setupAction =>
            {
                setupAction.AssumeDefaultVersionWhenUnspecified = true;
                setupAction.DefaultApiVersion = new ApiVersion(1, 0);
                setupAction.ReportApiVersions = true;
            });
            var apiVersionDescriptionProvider = GetVersionDescriptionProvider(services).
               GetService<IApiVersionDescriptionProvider>();
            services.AddSwaggerGen(setupAction =>
            {
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    setupAction.SwaggerDoc(
                        $"SessionSetupOpenAPISpecification{description.GroupName}",
                        new Microsoft.OpenApi.Models.OpenApiInfo()
                        {
                            Title = "Sessions API",
                            Version = description.ApiVersion.ToString(),
                            Description = "Through this API you can access auction session related information.",
                        });
                }
                setupAction.DocInclusionPredicate((documentName, apiDescription) =>
                {
                    var actionApiVersionModel = apiDescription.ActionDescriptor
                    .GetApiVersionModel(ApiVersionMapping.Explicit | ApiVersionMapping.Implicit);
                    if (actionApiVersionModel == null)
                    {
                        return true;
                    }
                    if (actionApiVersionModel.DeclaredApiVersions.Any())
                    {
                        return actionApiVersionModel.DeclaredApiVersions.Any(v =>
                        $"SessionSetupOpenAPISpecificationv{v.ToString()}" == documentName);
                    }
                    return actionApiVersionModel.ImplementedApiVersions.Any(v =>
                        $"SessionSetupOpenAPISpecificationv{v.ToString()}" == documentName);
                });
                var serviceXmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var serviceXmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, serviceXmlCommentsFile);
                setupAction.IncludeXmlComments(serviceXmlCommentsFullPath);
                var modelsXmlCommentsFile = "ASC.Online.AuctionApp.SessionSetup.Api.xml";
                var modelsXmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, modelsXmlCommentsFile);
                setupAction.IncludeXmlComments(modelsXmlCommentsFullPath);
            });
        }


        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        /// <param name="apiVersionDescriptionProvider">The API version description provider.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            if (env.IsProduction() || env.IsStaging())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
            {
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    setupAction.SwaggerEndpoint($"swagger/" +
                        $"SessionSetupOpenAPISpecification{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                }
                setupAction.RoutePrefix = string.Empty;
                setupAction.DefaultModelExpandDepth(2);
                setupAction.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);
                setupAction.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                setupAction.DisplayOperationId();
            });
            app.UseStatusCodePages();
            app.UseCors(builder => builder.WithOrigins("*")
                                          .AllowAnyHeader()
                                          .AllowAnyMethod());

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Returns build service provider
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private ServiceProvider GetVersionDescriptionProvider(IServiceCollection services)
        {
            return services.BuildServiceProvider();
        }
    }
}
