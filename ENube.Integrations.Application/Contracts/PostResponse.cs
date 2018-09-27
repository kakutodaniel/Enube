using System.Collections.Generic;

namespace ENube.Integrations.Application.Contracts
{
    public class PostResponse
    {

        public List<string> erros { get; set; } = new List<string>();

        public int statusCode { get; set; }
    }
}
