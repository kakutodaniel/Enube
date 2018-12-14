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
        public string CriadoPorNome { get; set; }

        [JsonProperty("empreendimentosId")]
        public string EmpreendimentosId { get; set; }

        [JsonProperty("empresaResponsavelId")]
        public string EmpresaResponsavelId { get; set; }

        [JsonProperty("forceDuplicate")]
        public bool ForceDuplicate { get; set; } = true;

        [JsonProperty("viuAlgumaComunicaoDoProduto")]
        public string Midia { get; set; }

        [JsonProperty("source")]
        public string Origem { get; set; } = "Campanha Online";


        [JsonProperty("tag")]
        public string[] Tag { get; set; } = new string[] { "compartilhar" };

    }
}

