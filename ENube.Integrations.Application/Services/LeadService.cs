using AutoMapper;
using ENube.Integrations.Application.Errors;
using ENube.Integrations.Application.Extensions;
using ENube.Integrations.Application.Services.CRM;
using ENube.Integrations.Application.Validators;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using ENube.Integrations.Application.Contracts;
using System.Net;

namespace ENube.Integrations.Application.Services
{
    public class LeadService
    {
        protected readonly ILogger<LeadService> _logger;
        protected readonly CRMService _CRMService;
        protected readonly IMapper _mapper;

        public LeadService(
            ILogger<LeadService> logger,
            CRMService CRMService,
            IMapper mapper)
        {
            _logger = logger;
            _CRMService = CRMService;
            _mapper = mapper;
        }

        public async Task<PostResponse> SaveGenericLead(PostRequest request)
        {
            var response = new PostResponse();
            var validator = new LeadPostRequestValidator();
            var results = validator.Validate(request);

            if (!results.IsValid)
            {
                results.Errors.ToList().ForEach(x => response.erros.Add(x.ErrorMessage));
                response.statusCode = (int)HttpStatusCode.BadRequest;

                return response;
            }

            var companyExists = await _CRMService.ExistsCompanyAsync(request.empreendimentosId);

            if (!companyExists)
            {
                response.erros.Add(EENubeErrors.EmpresaNaoEncontrada.GetDescription());
                response.statusCode = (int)HttpStatusCode.NotFound;

                return response;
            }

            var postCRM = _mapper.Map<CRM.Contracts.PostRequest>(request);
            var resultCRM = await _CRMService.PostAsync(postCRM);

            if (!resultCRM.Sucesso)
            {
                response.erros.Add(resultCRM.Mensagem);
                response.statusCode = resultCRM.CodigoStatus;

                return response;
            }

            response.statusCode = (int)HttpStatusCode.Created;
            return response;
        }


        public async Task<PostResponse> SaveZapLead(ZapPostRequest request)
        {
            var response = new PostResponse();
            var validator = new ZapPostRequestValidator();
            var results = validator.Validate(request);

            if (!results.IsValid)
            {
                results.Errors.ToList().ForEach(x => response.erros.Add(x.ErrorMessage));
                response.statusCode = (int)HttpStatusCode.BadRequest;

                return response;
            }

            //TODO: ID cONTROLE ??
            var companyExists = await _CRMService.ExistsCompanyAsync(request.id_controle);

            if (!companyExists)
            {
                response.erros.Add(EENubeErrors.EmpresaNaoEncontrada.GetDescription());
                response.statusCode = (int)HttpStatusCode.NotFound;

                return response;
            }

            var postCRM = _mapper.Map<CRM.Contracts.PostRequest>(request);
            var resultCRM = await _CRMService.PostAsync(postCRM);

            if (!resultCRM.Sucesso)
            {
                response.erros.Add(resultCRM.Mensagem);
                response.statusCode = resultCRM.CodigoStatus;

                return response;
            }

            response.statusCode = (int)HttpStatusCode.Created;
            return response;
        }

    }
}
