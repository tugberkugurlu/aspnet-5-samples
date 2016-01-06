using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Logging;

namespace LoggingSample
{
    public class RequestUrlLoggerMiddleware 
    {
        private readonly RequestDelegate _next;
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        
        public RequestUrlLoggerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory) 
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestUrlLoggerMiddleware>();
        }
        
        public Task Invoke (HttpContext context)
        {
            _logger.LogInformation("{Method}: {Url}", context.Request.Method, context.Request.Path);
            return _next(context);
        }
    }
}