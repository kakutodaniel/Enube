using Newtonsoft.Json;

namespace ENube.Integrations.Application.Contracts
{
    public class ZapPostRequest
    {
        public int versao { get; set; }

        public string id_controle { get; set; }

        public int id_cliente { get; set; }

        public string cod_oferta { get; set; }

        public ZapInteressadoPostRequest interessado { get; set; } = new ZapInteressadoPostRequest();

        public string mensagem { get; set; }

    }

    public class ZapInteressadoPostRequest
    {

        public string nome { get; set; }

        public string email { get; set; }

        public ZapInteressadoTelefonePostRequest telefone { get; set; } = new ZapInteressadoTelefonePostRequest();

    }

    public class ZapInteressadoTelefonePostRequest
    {

        public int ddd { get; set; }

        public string fone { get; set; }

    }



}
