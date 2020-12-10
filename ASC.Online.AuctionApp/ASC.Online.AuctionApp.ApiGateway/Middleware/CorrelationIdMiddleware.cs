using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ASC.Online.AuctionApp.ApiGateway.Middleware
{
    /// <summary>
    /// Correlation Id Middleware
    /// </summary>
    public class CorrelationIdMiddleware
    {
        #region Private Properties
        private readonly RequestDelegate next;
        private const string CorrelationIdHeaderName = "X-Correlation-Id";
        #endregion Private Properties

        public CorrelationIdMiddleware(RequestDelegate next)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
        }

        /// <summary>
        /// Invokes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public async Task Invoke(HttpContext context)
        {
            string correlationId = null;
            var key = context.Request.Headers.Keys.FirstOrDefault(n => n.ToLower().Equals(CorrelationIdHeaderName));
            if (!string.IsNullOrWhiteSpace(key))
            {
                correlationId = context.Request.Headers[key];
            }
            else
            {
                correlationId = Guid.NewGuid().ToString();
            }
            context.Request.Headers.Append(CorrelationIdHeaderName, correlationId);
            await this.next(context);
        }
    }
}
