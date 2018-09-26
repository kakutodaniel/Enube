using System.Linq;
using System.Net;
using ENube.Integrations.Application.Contracts;
using ENube.Integrations.Application.Services.CRM;
using ENube.Integrations.Application.Validators;
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
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PostResponse))]
        [ProducesResponseType((int)HttpStatusCode.Conflict, Type = typeof(PostResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(PostResponse))]
        public void PostZap([FromBody] ZapPostRequest request)
        {


        }

        [HttpPost("lead")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PostResponse))]
        [ProducesResponseType((int)HttpStatusCode.Conflict, Type = typeof(PostResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(PostResponse))]
        public IActionResult PostGeneric([FromBody] PostRequest request)
        {
            var response = new PostResponse();
            var validator = new LeadPostRequestValidator();
            var results = validator.Validate(request);

            if (!results.IsValid)
            {
                results.Errors.ToList().ForEach(x => response.Erros.Add(x.ErrorMessage));

                return BadRequest(response);
            }

            //TODO: call service

            response.Sucesso = true;
            return Ok(response);
        }


        [HttpGet("lead")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PostResponse))]
        [ProducesResponseType((int)HttpStatusCode.Conflict, Type = typeof(PostResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(PostResponse))]
        public IActionResult Get([FromQuery] PostRequest request)
        {

            var response = new PostResponse();
            var validator = new LeadPostRequestValidator();
            var results = validator.Validate(request);

            if (!results.IsValid)
            {
                results.Errors.ToList().ForEach(x => response.Erros.Add(x.ErrorMessage));

                return BadRequest(response);
            }

            //TODO: call service

            response.Sucesso = true;
            return Ok(response);

        }
    }
}
