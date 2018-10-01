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
using ENube.Integrations.Application.Services;
using AutoMapper;
using ENube.Integrations.Application.Mappings;
using ENube.Integrations.Application.Filters;

namespace ENube.Integrations.Application
{
    public class ENubeConfiguration
    {

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //IOptions
            services.AddOptions();

            //config swashbuckle
            services.AddSwaggerGen(opt =>
            {
                opt.OperationFilter<AddAuthorizationHeaderParameterOperationFilter>();

                opt.SwaggerDoc("v1.0", new Info { Title = "ENube Integrations API", Version = "v1.0" });

                //opt.AddSecurityDefinition("Basic", new ApiKeyScheme { In = "Header", Description = "Por favor, insira o token com Basic no campo", Name = "Authorization", Type = "apiKey" });

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
            //services.Configure<CRMSettings>(configuration.GetSection(nameof(CRMSettings)));
            services.Configure<CRMSettings>(configuration.GetSection(CRMSettings.Section));
            services.TryAddSingleton(resolver => resolver.GetRequiredService<IOptions<CRMSettings>>().Value);

            //services
            services.TryAddScoped<CRMService>();
            services.TryAddScoped<LeadService>();

            //config httpClient typed
            var crmSettings = configuration.GetSection(CRMSettings.Section).Get<CRMSettings>();
            //var basicToken = ($"{crmSettings.User}:{crmSettings.Password}").Base64Encode();

            services.AddHttpClient<CRMService>(opt =>
            {
                opt.BaseAddress = new Uri(crmSettings.UrlBase);
                opt.DefaultRequestHeaders.Accept.Clear();
                opt.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(crmSettings.ContentType));
                //opt.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", basicToken);

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

            //automapper
            Mapper.Initialize(config =>
            {
                config.AllowNullCollections = true;
                config.AllowNullDestinationValues = true;
                config.CreateMissingTypeMaps = true;
                config.EnableNullPropagationForQueryMapping = true;

                config.AddProfile(new PostRequestMap());
                config.AddProfile(new ZapPostRequestMap());

            });

            services.TryAddSingleton(Mapper.Instance);

            //context
            services.AddHttpContextAccessor();

        }

    }
}
