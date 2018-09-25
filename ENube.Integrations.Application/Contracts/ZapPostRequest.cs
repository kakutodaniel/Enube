using Newtonsoft.Json;

namespace ENube.Integrations.Application.Contracts
{
    public class ZapPostRequest
    {
        [JsonProperty("versao")]
        public int Versao { get; set; }

        [JsonProperty("id_controle")]
        public string ControleId { get; set; }

        [JsonProperty("id_cliente")]
        public int ClienteId { get; set; }

        [JsonProperty("cod_oferta")]
        public string CodigoOferta { get; set; }

        [JsonProperty("interessado")]
        public ZapInteressadoPostRequest Interessado { get; set; }

        [JsonProperty("mensagem")]
        public string Mensagem { get; set; }

    }

    public class ZapInteressadoPostRequest
    {

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("telefone")]
        public ZapInteressadoTelefonePostRequest Telefone { get; set; }

    }

    public class ZapInteressadoTelefonePostRequest
    {

        [JsonProperty("ddd")]
        public int DDD { get; set; }

        [JsonProperty("fone")]
        public string Telefone { get; set; }

    }



}
