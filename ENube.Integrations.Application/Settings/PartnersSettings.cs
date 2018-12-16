using ENube.Integrations.Application.Enums;

namespace ENube.Integrations.Application.Settings
{
    public class PartnersSettings
    {
        public static string Section = "PartnersSettings";

        public ParterSettingsConfigurations[] Partners { get; set; }
    }

    public class ParterSettingsConfigurations
    {
        public string User { get; set; }

        public string Password { get; set; }

        public bool EnableAuthDefault { get; set; }

        public EENubePartners EPartner { get; set; }
    }
}
