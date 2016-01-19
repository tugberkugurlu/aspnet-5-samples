using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Features;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ProductsWebApp
{
    public class Startup 
    {   
        public Startup(ILoggerFactory loggerFactory) 
        {
            loggerFactory.MinimumLevel = LogLevel.Debug;
            loggerFactory.AddConsole();
        }
        
        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<RequestIdMiddleware>();
            app.UseMvc();
        }
        
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
    
    [Route("products")]
    public class ProductsController : Controller 
    {
        [HttpGet]
        public string[] Get() 
        {
            return new[]
            {
                "Product 1",
                "Product 2",
                "Product 3"
            };
        }
    }
    
    public class RequestIdMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestIdMiddleware(RequestDelegate next, ILogger<RequestIdMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var requestIdFeature = context.Features.Get<IHttpRequestIdentifierFeature>();
            if (requestIdFeature?.TraceIdentifier != null)
            {
                _logger.LogInformation("Setting request id header: {requestId}", requestIdFeature.TraceIdentifier);
                context.Response.Headers["RequestId"] = requestIdFeature.TraceIdentifier;
            }
            else 
            {
                _logger.LogInformation("No request id");
            }

            await _next(context);
        }
    }
}