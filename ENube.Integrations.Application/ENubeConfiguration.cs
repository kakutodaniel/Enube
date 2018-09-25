using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.Linq;

namespace ENube.Integrations.Application
{
    public class ENubeConfiguration
    {

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1.0", new Info { Title = "ENube Integrations API", Version = "v1.0" });

                opt.DocInclusionPredicate((version, apiDescription) =>
                {
                    var values = apiDescription.RelativePath
                        .Split('/')
                        .Select(v => v.Replace("v{version}", version));

                    apiDescription.RelativePath = string.Join("/", values);

                    var versionParameter = apiDescription.ParameterDescriptions
                        .SingleOrDefault(p => p.Name == "version");

                    if (versionParameter != null)
                        apiDescription.ParameterDescriptions.Remove(versionParameter);

                    return true;
                });
            });

            services.AddApiVersioning(opt =>
            {
                opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.ApiVersionReader = new MediaTypeApiVersionReader();

            });


        }

    }
}
