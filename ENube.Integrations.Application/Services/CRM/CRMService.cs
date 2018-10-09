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
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using ENube.Integrations.Application.Enums;
using ENube.Integrations.Application.Extensions;

namespace ENube.Integrations.Application.Services.CRM
{
    public class CRMService
    {
        public EENubePartners _eNubePartner { get; private set; }

        private readonly HttpClient _httpClient;
        private readonly CRMSettings _crmSettings;
        private readonly PartnersSettings _partnersSettings;
        private readonly ILogger<CRMService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CRMService(
            HttpClient httpClient,
            CRMSettings crmSettings,
            PartnersSettings partnersSettings,
            ILogger<CRMService> logger,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _crmSettings = crmSettings;
            _partnersSettings = partnersSettings;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<StatusResponse> PostAsync(PostRequest request)
        {

            var response = new StatusResponse();

            try
            {
                SetAuthorization();

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

                    if (result.Headers.TryGetValues("x-status-reason", out var results))
                    {
                        var headerStatus = results.FirstOrDefault();

                        var headerDataParse = JsonConvert.DeserializeObject<ErrorView>(headerStatus);
                        _logger.LogInformation($"Dados não foram salvos com sucesso no CRM - Reason: [{headerDataParse.reason}]");
                        response.Mensagem = headerDataParse.reason;
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

        public async Task<StatusResponse> CheckCompanyAsync(string id)
        {
            var response = new StatusResponse();

            try
            {
                SetAuthorization();

                _logger.LogInformation($"Realizando busca de empresa no CRM - id: [{id}]");

                var result = await _httpClient.GetAsync($"{_crmSettings.GetEndpoint}/{id}");

                response.CodigoStatus = (int)result.StatusCode;

                if (result.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"Empresa encontrada no CRM - StatusCode: [{(int)result.StatusCode}]");
                    response.Sucesso = true;
                }
                else
                {
                    _logger.LogInformation($"Erro ao realizar busca de empresa no CRM - StatusCode: [{(int)result.StatusCode}]");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao realizar busca de empresa no CRM {_crmSettings.UrlBase}/{_crmSettings.GetEndpoint}");
            }

            return response;
        }

        public void SetPartner(EENubePartners eNubePartner)
        {
            _eNubePartner = eNubePartner;
        }

        private void SetAuthorization()
        {
            var auth = string.Empty;
            var currentPartner = _partnersSettings.Partners.FirstOrDefault(x => x.EPartner == _eNubePartner);

            if (currentPartner == null)
                return;

            if (currentPartner.EnableAuthDefault)
            {
                auth = $"{currentPartner.User}:{currentPartner.Password}".Base64Encode();
            }
            else
            {
                auth = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ")[1];
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);
        }
    }
}
