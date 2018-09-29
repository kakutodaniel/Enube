using Newtonsoft.Json;
using System;

namespace ENube.Integrations.Application.Services.CRM.Contracts
{
    public class PostRequest
    {

        [JsonProperty("name")]
        public string Nome { get; set; }

        [JsonProperty("deleted")]
        public bool Excluido { get; set; }

        [JsonProperty("firstName")]
        public string PrimeiroNome { get; set; }

        [JsonProperty("lastName")]
        public string SobreNome { get; set; }

        [JsonProperty("isActive")]
        public bool Ativo { get; set; } = true;

        [JsonProperty("title")]
        public string Titulo { get; set; }

        [JsonProperty("emailAddress")]
        public string Email { get; set; }

        [JsonProperty("phoneNumber")]
        public string Telefone { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("createdAt")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        [JsonProperty("createdById")]
        public string CriadoPorId { get; set; } = "1";

        [JsonProperty("createdByName")]
        public string CriadoPorNome { get; set; } = "Admin";

        [JsonProperty("forceDuplicate")]
        public bool ForceDuplicate { get; set; } = true;

        [JsonProperty("viuAlgumaComunicaoDoProduto")]
        public string Midia { get; set; }

        [JsonProperty("source")]
        public string Origem { get; set; }

    }
}



  //"name": "Nicolas Carvalho", (Required)
  //"deleted": false, (Required)
  // "firstName": "Nicolas", (Required)
  //"lastName": "Carvalho", (Required)
  //"isActive": true, (Required)
  //"title": "", (Required)
  //"emailAddress":  nicolas @enube.me", (Required)
  //"phoneNumber": null, (Required)
  //"createdAt": "2018-03-12 17:06:20", (Required)
  //"createdById": "1", (Required)
  //"createdByName": "Admin" (Required)
