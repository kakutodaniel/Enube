using Newtonsoft.Json;

namespace ENube.Integrations.Application.Contracts
{
    public class PostResponse
    {

        [JsonProperty("sucesso")]
        public bool Sucesso { get; set; }

        [JsonProperty("mensagem")]
        public string Mensagem { get; set; }

    }
}
