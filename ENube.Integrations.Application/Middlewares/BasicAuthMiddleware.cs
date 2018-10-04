using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace ENube.Integrations.Application.Middlewares
{
    public class BasicAuthMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly string _realm;

        public BasicAuthMiddleware(
            RequestDelegate next,
            string realm)
        {
            _next = next;
            _realm = realm;
        }

        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                await _next.Invoke(context);
                return;
            }

            context.Response.Headers["WWW-Authenticate"] = "Basic";

            if (!string.IsNullOrWhiteSpace(_realm))
            {
                context.Response.Headers["WWW-Authenticate"] += $" realm=\"{_realm}\"";
            }
            
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
    }
}
