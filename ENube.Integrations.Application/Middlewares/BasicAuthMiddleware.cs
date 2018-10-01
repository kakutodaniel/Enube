using ENube.Integrations.Application.Services.CRM;
using ENube.Integrations.Application.Settings;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ENube.Integrations.Application.Middlewares
{
    public class BasicAuthMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly CRMSettings _CRMSettings;
        private readonly CRMService _CRMService;
        private readonly string _realm;

        public BasicAuthMiddleware(
            RequestDelegate next,
            CRMSettings CRMSettings,
            CRMService CRMService,
            string realm)
        {
            _next = next;
            _CRMSettings = CRMSettings;
            _CRMService = CRMService;
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

        public bool IsAuthorized(string username, string password)
        {
            
            return username.Equals(_CRMSettings.User, StringComparison.InvariantCultureIgnoreCase)
                   && password.Equals(_CRMSettings.Password);
        }

    }
}
