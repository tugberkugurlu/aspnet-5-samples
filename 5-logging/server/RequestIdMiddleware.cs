using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Features;

namespace LoggingSample
{
    public class RequestIdMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var requestIdFeature = context.Features.Get<IHttpRequestIdentifierFeature>();
            if (requestIdFeature?.TraceIdentifier != null)
            {
                context.Response.Headers["RequestId"] = requestIdFeature.TraceIdentifier;
            }

            await _next(context);
        }
    }
}