using AutoMapper;
using EmprestimoLivros.Application.DTOs.Editora.Request;
using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Application.Mappings.AutoMapperConfig
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CadastrarEditoraRequestDTO, Editora>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dest => dest.CNPJ, opt => opt.MapFrom(src => src.CNPJ))
                  .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));

                cfg.CreateMap<AlterarEditoraRequestDTO, Editora>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dest => dest.CNPJ, opt => opt.MapFrom(src => src.CNPJ))
                  .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));

             
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
