using AutoMapper;
using ENube.Integrations.Application.Contracts;
using CRM = ENube.Integrations.Application.Services.CRM.Contracts;
using ENube.Integrations.Application.Extensions;

namespace ENube.Integrations.Application.Mappings
{
    public class ZapPostRequestMap : Profile
    {

        public ZapPostRequestMap()
        {

            CreateMap<ZapPostRequest, CRM.PostRequest>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.interessado.nome))
                .ForMember(dest => dest.PrimeiroNome, opt => opt.MapFrom(src => src.interessado.nome.GetFirstName()))
                .ForMember(dest => dest.SobreNome, opt => opt.MapFrom(src => src.interessado.nome.GetLastName()))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.interessado.email))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => $"{src.interessado.telefone.ddd.ToString()}-{src.interessado.telefone.fone}"))
                .ForMember(dest => dest.CriadoPorId, opt => opt.MapFrom(src => src.id_cliente));

        }


    }
}
