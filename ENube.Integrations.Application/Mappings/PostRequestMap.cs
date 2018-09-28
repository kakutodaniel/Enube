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
                .ForMember(dest => dest.CriadoPorId, opt => opt.MapFrom(src => src.createdById))
                .ForMember(dest => dest.CriadoPorNome, opt => opt.UseValue("Admin"))
                .ForMember(dest => dest.EmpreendimentosId, opt => opt.MapFrom(src => src.empreendimentosId))
                .ForMember(dest => dest.ViuAlgumaComunicacao, opt => opt.MapFrom(src => src.viuAlgumaComunicaoDoProduto))
                .ForMember(dest => dest.EmpresaResponsavelId, opt => opt.UseValue("5b2809f0953ea290f"))
                .ForMember(dest => dest.Source, opt => opt.UseValue("Campanha Online"));

        }

    }
}
