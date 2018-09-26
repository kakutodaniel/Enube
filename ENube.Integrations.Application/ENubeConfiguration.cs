using ENube.Integrations.Application.Services.CRM;
using ENube.Integrations.Application.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Linq;
using System.Net.Http.Headers;

namespace ENube.Integrations.Application
{
    public class ENubeConfiguration
    {

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();

            //config swashbuckle
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

            //compress json
            services.Configure<GzipCompressionProviderOptions>(opt => opt.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.AddResponseCompression(opt => opt.Providers.Add<GzipCompressionProvider>());

            //settings
            services.Configure<CRMSettings>(configuration.GetSection(nameof(CRMSettings)));
            services.TryAddSingleton(resolver => resolver.GetRequiredService<IOptions<CRMSettings>>().Value);

            //services
            services.TryAddScoped<CRMService>();

            //config httpClient typed
            var crmSettings = configuration.GetSection(CRMSettings.Section).Get<CRMSettings>();
            services.AddHttpClient<CRMService>(opt =>
            {
                opt.BaseAddress = new Uri(crmSettings.UrlBase);
                opt.DefaultRequestHeaders.Accept.Clear();
                opt.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(crmSettings.ContentType));

                //TODO: checar
                //opt.DefaultRequestHeaders.Add("Content-type", crmSettings.ContentType);
                //opt.DefaultRequestHeaders.Add("Authorization", crmSettings.Authorization);

            }) //retry 2 times every 600 ms
            .AddTransientHttpErrorPolicy(opt => opt.WaitAndRetryAsync(2, x => TimeSpan.FromMilliseconds(600)));

            //logging
            services.AddLogging(opt =>
            {
                opt.AddConsole();
                opt.AddDebug();
                opt.AddFile(configuration.GetSection("Logging"));
                opt.AddConfiguration(configuration.GetSection("Logging"));
            });

        }

    }
}
