using ENube.Integrations.Application.Services.CRM.Contracts;
using ENube.Integrations.Application.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ENube.Integrations.Application.Services.CRM
{
    public class CRMService
    {
        protected readonly HttpClient _httpClient;
        protected readonly CRMSettings _crmSettings;
        protected readonly ILogger<CRMService> _logger;

        public CRMService(
            HttpClient httpClient,
            CRMSettings crmSettings,
            ILogger<CRMService> logger)
        {
            _httpClient = httpClient;
            _crmSettings = crmSettings;
            _logger = logger;
        }


        public async Task<PostResponse> PostAsync(PostRequest request)
        {

            var response = new PostResponse();

            try
            {
                var payload = JsonConvert.SerializeObject(request);

                _logger.LogInformation($"Realizando POST no CRM - Payload: [{payload}]");

                var result = await _httpClient.PostAsync(
                        _crmSettings.PostEndpoint,
                        new StringContent(payload, Encoding.UTF8, _crmSettings.ContentType)
                    );

                response.CodigoStatus = (int)result.StatusCode;

                if (result.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"POST no CRM realizado com SUCESSO - StatusCode: [{response.CodigoStatus}]");
                    response.Sucesso = true;
                }
                else
                {
                    _logger.LogInformation($"POST no CRM realizado com ERRO - StatusCode: [{response.CodigoStatus}]");
                    var headerStatus = result.Headers.GetValues("x-status-reason").FirstOrDefault();
                    if (headerStatus != null)
                    {
                        var headerDataParse = JsonConvert.DeserializeObject<Dictionary<string, string>>(headerStatus);
                        if (headerDataParse.ContainsKey("reason"))
                        {
                            _logger.LogInformation($"POST no CRM realizado com ERRO - Reason: [{headerDataParse["reason"]}]");
                            response.Mensagem = headerDataParse["reason"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"ERRO ao realizar POST no CRM {_crmSettings.UrlBase}/{_crmSettings.PostEndpoint}");
            }

            return response;
        }


        public async Task<bool> ExistsAsync(string id)
        {

            try
            {
                _logger.LogInformation($"Realizando GET no CRM - id: [{id}]");

                var result = await _httpClient.GetAsync(_crmSettings.GetEndpoint);

                if (result.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"GET no CRM realizado com SUCESSO - StatusCode: [{(int)result.StatusCode}]");
                    return true;
                }

                _logger.LogInformation($"GET no CRM realizado com ERRO - StatusCode: [{(int)result.StatusCode}]");
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"ERRO ao realizar GET no CRM {_crmSettings.UrlBase}/{_crmSettings.GetEndpoint}");
                return false;
            }
        }
    }
}
