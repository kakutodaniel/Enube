using AutoMapper;
using CRM = ENube.Integrations.Application.Services.CRM.Contracts;
using API = ENube.Integrations.Application.Contracts;
using ENube.Integrations.Application.Extensions;

namespace ENube.Integrations.Application.Mappings
{
    public class PostRequestMap : Profile
    {

        public PostRequestMap()
        {

            CreateMap<API.PostRequest, CRM.PostRequest>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.PrimeiroNome, opt => opt.MapFrom(src => src.name.GetFirstName()))
                .ForMember(dest => dest.SobreNome, opt => opt.MapFrom(src => src.name.GetLastName()))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.emailAddress))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.phoneNumber))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.description))
                .ForMember(dest => dest.Midia, opt => opt.MapFrom(src => src.midia))
                .ForMember(dest => dest.Origem, opt => opt.MapFrom(src => src.source))
                .ForMember(dest => dest.CriadoPorId, opt => opt.MapFrom(src => src.createdById));
        }

    }
}
