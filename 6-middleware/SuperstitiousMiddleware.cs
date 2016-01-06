using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Logging;

namespace MiddlewareSample
{
    /// <remarks>
    /// Example for a request terminating middleware.
    /// </remarks>
    public class SuperstitiousMiddleware 
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        
        public SuperstitiousMiddleware(RequestDelegate next, ILogger<SuperstitiousMiddleware> logger)
        {
            if (next == null) throw new System.ArgumentNullException(nameof(next));
            if (logger == null) throw new System.ArgumentNullException(nameof(logger));
            
            _next = next;
            _logger = logger;
        }
        
        public Task Invoke(HttpContext context) 
        {
            if(context.Request.Path.Value.Contains("13") || context.Request.QueryString.Value.Contains("13")) 
            {
                _logger.LogWarning("13 can bring bad luck, let's just go home!");
                
                context.Response.StatusCode = 418;
                return context.Response.WriteAsync("Request contains 13 :sadpanda:");
            }
            
            return _next.Invoke(context);
        }
    }
}