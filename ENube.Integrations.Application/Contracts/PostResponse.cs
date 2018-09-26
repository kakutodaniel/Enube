using Newtonsoft.Json;
using System.Collections.Generic;

namespace ENube.Integrations.Application.Contracts
{
    public class PostResponse
    {

        [JsonProperty("sucesso")]
        public bool Sucesso { get; set; }

        [JsonProperty("mensagem")]
        public string Mensagem { get; set; }

        [JsonProperty("erros")]
        public List<string> Erros { get; set; } = new List<string>();

    }
}
