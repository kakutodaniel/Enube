using AutoMapper;
using ENube.Integrations.Application.Contracts;
using CRM = ENube.Integrations.Application.Services.CRM.Contracts;
using ENube.Integrations.Application.Extensions;

namespace ENube.Integrations.Application.Mappings
{
    public class VivaRealPostRequestMap : Profile
    {

        public VivaRealPostRequestMap()
        {


            CreateMap<VivaRealPostRequest, CRM.PostRequest>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Origem, opt => opt.MapFrom(src => src.leadOrigin))
                .ForMember(dest => dest.DataCriacao, opt => opt.MapFrom(src => src.timestamp))
                .ForMember(dest => dest.CriadoPorId, opt => opt.MapFrom(src => src.originLeadId))
                .ForMember(dest => dest.EmpreendimentosId, opt => opt.MapFrom(src => src.originListingId))
                .ForMember(dest => dest.EmpresaResponsavelId, opt => opt.MapFrom(src => src.clientListingId))
                .ForMember(dest => dest.EmpresaResponsavelId, opt => opt.MapFrom(src => src.clientListingId))
                .ForMember(dest => dest.PrimeiroNome, opt => opt.MapFrom(src => src.name.GetFirstName()))
                .ForMember(dest => dest.SobreNome, opt => opt.MapFrom(src => src.name.GetLastName()))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.phoneNumber))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.message));
        }


    }
}
