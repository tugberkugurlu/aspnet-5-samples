using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace TestingSample 
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<CarsRepository>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
        
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}