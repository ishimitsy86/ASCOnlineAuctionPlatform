using ASC.Online.AuctionApp.Framework.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ASC.Online.AuctionApp.Framework.Utility.Middleware
{
    /// <summary>
    /// Exception Middleware class
    /// </summary>
    public class ExceptionMiddleware
    {
        #region Member Variables        
        /// <summary>
        /// The next
        /// </summary>
        private readonly RequestDelegate next;
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<ExceptionMiddleware> logger;
        #endregion Member Variables

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="System.ArgumentNullException">
        /// next
        /// or
        /// logger
        /// </exception>
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        #endregion

        #region Public Methods        
        /// <summary>
        /// Invokes the asynchronous.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        #endregion Public Methods

        #region Private Methods
        /// <summary>
        /// Handles the exception asynchronous.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="ex">The ex.</param>
        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var message = ex.Message;
            var description = "Error occured in downstream service. Please contact your administrator!!";

            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = statusCode;
            logger.LogError($"{ex}");

            await response.WriteAsync(JsonConvert.SerializeObject(new ErrorDetails
            {
                Message = message,
                Description = description,
                StatusCode = statusCode
            }));
        }
        #endregion Private Methods
    }
}
