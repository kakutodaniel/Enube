using System.Net;
using System.Threading.Tasks;
using ENube.Integrations.Application.Contracts;
using ENube.Integrations.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ENube.Integrations.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        protected readonly LeadService _leadService;

        public LeadController(LeadService leadService)
        {
            _leadService = leadService;
        }

        [HttpPost("lead/zap")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.Conflict, Type = typeof(PostResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(PostResponse))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(PostResponse))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(PostResponse))]
        public async Task<IActionResult> PostZap([FromBody] ZapPostRequest request)
        {
            var result = await _leadService.SaveZapLead(request);
            return StatusCode(result.statusCode, result);
        }

        [HttpPost("lead/vivareal")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.Conflict, Type = typeof(PostResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(PostResponse))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(PostResponse))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(PostResponse))]
        public async Task<IActionResult> PostVivaReal([FromBody] VivaRealPostRequest request)
        {
            var result = await _leadService.SaveVivaRealLead(request);
            return StatusCode(result.statusCode, result);
        }

        [HttpPost("lead")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.Conflict, Type = typeof(PostResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(PostResponse))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(PostResponse))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(PostResponse))]
        public async Task<IActionResult> PostGeneric([FromBody] PostRequest request)
        {
            var result = await _leadService.SaveGenericLead(request);
            return StatusCode(result.statusCode, result);
        }


        [HttpGet("lead")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.Conflict, Type = typeof(PostResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(PostResponse))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(PostResponse))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(PostResponse))]
        public async Task<IActionResult> Get([FromQuery] PostRequest request)
        {
            var result = await _leadService.SaveGenericLead(request);
            return StatusCode(result.statusCode, result);
        }
    }
}
