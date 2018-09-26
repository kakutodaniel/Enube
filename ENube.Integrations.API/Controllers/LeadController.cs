using System.Net;
using ENube.Integrations.Application.Contracts;
using ENube.Integrations.Application.Services.CRM;
using Microsoft.AspNetCore.Mvc;

namespace ENube.Integrations.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        protected readonly CRMService _crmService;

        public LeadController(CRMService crmService)
        {
            _crmService = crmService;
        }

        [HttpPost("lead/zap")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        public void PostZap([FromBody] ZapPostRequest request)
        {


        }

        [HttpPost("lead")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        public void PostGeneric([FromBody] PostRequest request)
        {


        }


        [HttpGet("lead")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        public void Get([FromQuery] PostRequest request)
        {


        }


    }
}
