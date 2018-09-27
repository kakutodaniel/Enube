using ENube.Integrations.Application.Services.CRM.Contracts;
using ENube.Integrations.Application.Settings;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Net;
using ENube.Integrations.Application.Services.CRM.Views;

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

                _logger.LogInformation($"Salvando dados no CRM - Payload: [{payload}]");

                var result = await _httpClient.PostAsync(
                        _crmSettings.PostEndpoint,
                        new StringContent(payload, Encoding.UTF8, _crmSettings.ContentType)
                    );

                response.CodigoStatus = (int)result.StatusCode;

                if (result.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"Dados salvo com sucesso no CRM - StatusCode: [{response.CodigoStatus}]");
                    response.Sucesso = true;
                }
                else
                {
                    _logger.LogInformation($"Dados não foram salvos com sucesso no CRM - StatusCode: [{response.CodigoStatus}]");
                    var headerStatus = result.Headers.GetValues("x-status-reason").FirstOrDefault();
                    if (headerStatus != null)
                    {
                        var headerDataParse = JsonConvert.DeserializeObject<ErrorView>(headerStatus);
                        _logger.LogInformation($"Dados não foram salvos com sucesso no CRM - Reason: [{headerDataParse.reason}]");
                        response.Mensagem = headerDataParse.reason;
                    }
                    else
                    {
                        response.Mensagem = "I) Erro inesperado ao salvar dados no CRM";
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao salvar dados no CRM {_crmSettings.UrlBase}/{_crmSettings.PostEndpoint}");
                response.CodigoStatus = (int)HttpStatusCode.InternalServerError;
                response.Mensagem = "II) Erro inesperado ao salvar dados no CRM";
            }

            return response;
        }


        public async Task<bool> ExistsCompanyAsync(string id)
        {

            try
            {
                _logger.LogInformation($"Realizando busca de empresa no CRM - id: [{id}]");

                var result = await _httpClient.GetAsync($"{_crmSettings.GetEndpoint}/{id}");

                if (result.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"Empresa encontrada no CRM - StatusCode: [{(int)result.StatusCode}]");
                    return true;
                }

                _logger.LogInformation($"Empresa não encontrada no CRM - StatusCode: [{(int)result.StatusCode}]");
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao realizar busca de empresa no CRM {_crmSettings.UrlBase}/{_crmSettings.GetEndpoint}");
                return false;
            }
        }
    }
}
