using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ENube.Integrations.Application.Contracts
{
    public class PostRequest
    {
        [JsonProperty("name")]
        [FromQuery(Name = "name")]
        public string Nome { get; set; }

        [JsonProperty("emailAddress")]
        [FromQuery(Name = "emailAddress")]
        public string Email { get; set; }

        [JsonProperty("phoneNumber")]
        [FromQuery(Name = "phoneNumber")]
        public string Telefone { get; set; }

        [JsonProperty("description")]
        [FromQuery(Name = "description")]
        public string Descricao { get; set; }

        [JsonProperty("createdById")]
        [FromQuery(Name = "createdById")]
        public string CriadoPor { get; set; }

        [JsonProperty("viuAlgumaComunicaoDoProduto")]
        [FromQuery(Name = "viuAlgumaComunicaoDoProduto")]
        public string ViuComunicacao { get; set; }

        [JsonProperty("empreendimentosId")]
        [FromQuery(Name = "empreendimentosId")]
        public string EmpreendimentosIds { get; set; }


    }
}
