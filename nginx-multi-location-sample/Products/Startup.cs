using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
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
}