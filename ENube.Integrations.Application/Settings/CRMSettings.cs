namespace ENube.Integrations.Application.Settings
{
    public class CRMSettings
    {

        public static string Section = "CRMSettings";

        public string UrlBase { get; set; }

        public string PostEndpoint { get; set; }

        public string GetEndpoint { get; set; }

        public string ContentType { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

    }
}
