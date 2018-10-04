using System;

namespace ENube.Integrations.Application.Contracts
{
    public class VivaRealPostRequest
    {
        public string leadOrigin { get; set; }

        public string timestamp { get; set; }

        public string originLeadId { get; set; }

        public string originListingId { get; set; }

        public string clientListingId { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string ddd { get; set; }

        public string phone { get; set; }

        public string phoneNumber { get; set; }

        public string message { get; set; }


    }
}
