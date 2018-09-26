using ENube.Integrations.Application.Services.CRM.Contracts;
using ENube.Integrations.Application.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ENube.Integrations.Application.Services.CRM
{
    public class CRMService
    {
        protected readonly HttpClient _httpClient;
        protected readonly CRMSettings _crmSettings;

        public CRMService(
            HttpClient httpClient,
            CRMSettings crmSettings)
        {
            _httpClient = httpClient;
            _crmSettings = crmSettings;
        }


        public async Task Post(PostRequest request)
        {
            try
            {
                var payload = JsonConvert.SerializeObject(request);

                var response = await _httpClient.PostAsync(
                        _crmSettings.Endpoint,
                        new StringContent(payload, Encoding.UTF8, _crmSettings.ContentType)
                    );

                response.EnsureSuccessStatusCode();

                var result = response.Content;

            }
            catch (Exception ex)
            {

                throw;
            }




        }



    }
}
