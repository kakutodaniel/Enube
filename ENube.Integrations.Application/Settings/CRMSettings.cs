namespace ENube.Integrations.Application.Settings
{
    public class CRMSettings
    {

        public static string Section = "CRM";

        public string UrlBase { get; set; }

        public string Endpoint { get; set; }

        public string ContentType { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

    }
}
