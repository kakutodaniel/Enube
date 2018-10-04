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
        private readonly ILogger<LeadService> _logger;
        private readonly IMapper _mapper;
        private readonly CRMService _CRMService;

        public LeadService(
            ILogger<LeadService> logger,
            IMapper mapper,
            CRMService CRMService)
        {
            _logger = logger;
            _mapper = mapper;
            _CRMService = CRMService;
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

            var resultExistsCompany = await _CRMService.CheckCompanyAsync(request.empreendimentosId);

            if (!resultExistsCompany.Sucesso)
            {
                if (resultExistsCompany.CodigoStatus == (int)HttpStatusCode.Unauthorized)
                {
                    response.erros.Add(EENubeErrors.Unauthorized.GetDescription());
                }
                else
                {
                    response.erros.Add(EENubeErrors.EmpresaNaoEncontrada.GetDescription());
                }

                response.statusCode = resultExistsCompany.CodigoStatus;

                return response;
            }

            var postCRM = _mapper.Map<CRM.Contracts.PostRequest>(request);
            var resultCRM = await _CRMService.PostAsync(postCRM);

            if (!resultCRM.Sucesso)
            {
                if (resultCRM.CodigoStatus == (int)HttpStatusCode.Unauthorized)
                {
                    response.erros.Add(EENubeErrors.Unauthorized.GetDescription());
                }
                else
                {
                    response.erros.Add(resultCRM.Mensagem);
                }

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

            var postCRM = _mapper.Map<CRM.Contracts.PostRequest>(request);
            var resultCRM = await _CRMService.PostAsync(postCRM);


            if (!resultCRM.Sucesso)
            {
                if (resultCRM.CodigoStatus == (int)HttpStatusCode.Unauthorized)
                {
                    response.erros.Add(EENubeErrors.Unauthorized.GetDescription());
                }
                else
                {
                    response.erros.Add(resultCRM.Mensagem);
                }

                response.statusCode = resultCRM.CodigoStatus;

                return response;
            }

            response.statusCode = (int)HttpStatusCode.Created;
            return response;
        }

        public async Task<PostResponse> SaveVivaRealLead(VivaRealPostRequest request)
        {
            var response = new PostResponse();
            var validator = new VivaRealPostRequestValidator();
            var results = validator.Validate(request);

            if (!results.IsValid)
            {
                results.Errors.ToList().ForEach(x => response.erros.Add(x.ErrorMessage));
                response.statusCode = (int)HttpStatusCode.BadRequest;

                return response;
            }

            var postCRM = _mapper.Map<CRM.Contracts.PostRequest>(request);
            var resultCRM = await _CRMService.PostAsync(postCRM);


            if (!resultCRM.Sucesso)
            {
                if (resultCRM.CodigoStatus == (int)HttpStatusCode.Unauthorized)
                {
                    response.erros.Add(EENubeErrors.Unauthorized.GetDescription());
                }
                else
                {
                    response.erros.Add(resultCRM.Mensagem);
                }

                response.statusCode = resultCRM.CodigoStatus;

                return response;
            }

            response.statusCode = (int)HttpStatusCode.Created;
            return response;
        }

    }
}
