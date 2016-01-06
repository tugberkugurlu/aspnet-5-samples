using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;

namespace MiddlewareSample 
{
    /// <remarks>
    /// Example for a response modifier and a pass-through middleware.
    /// </remarks>
    public class VersionHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        
        public VersionHeaderMiddleware(RequestDelegate next)
        {
            if (next == null)
            {
                throw new System.ArgumentNullException(nameof(next));   
            }
            
            _next = next;
        }
        
        public Task Invoke(HttpContext context)
        {   
            context.Response.Headers.Add("app-version", "1.1.0");
            return _next.Invoke(context);
        }
    } 
}