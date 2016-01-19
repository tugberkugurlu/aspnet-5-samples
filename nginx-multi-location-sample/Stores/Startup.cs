using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace StoresWebApp
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
    
    [Route("stores")]
    public class ProductsController : Controller 
    {
        [HttpGet]
        public string[] Get() 
        {
            return new[]
            {
                "Store 1",
                "Store 2",
                "Store 3"
            };
        }
    }
}