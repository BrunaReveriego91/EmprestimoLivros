using AutoMapper;
using EmprestimoLivros.Application.DTOs.AreaConhecimento.Request;
using EmprestimoLivros.Application.DTOs.Editora.Request;
using EmprestimoLivros.Application.DTOs.Publicacao.Request;
using EmprestimoLivros.Application.DTOs.TipoPublicacao.Request;
using EmprestimoLivros.Application.DTOs.Usuario.Request;
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

                cfg.CreateMap<CadastrarPublicacaoRequestDTO, Publicacao>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                  .ForMember(dest => dest.Autor, opt => opt.MapFrom(src => src.Autor))
                  .ForMember(dest => dest.AnoDeLancamento, opt => opt.MapFrom(src => src.AnoDeLancamento))
                  .ForMember(dest => dest.ISBN, opt => opt.MapFrom(src => src.ISBN))
                  .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                  .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags));

                cfg.CreateMap<CadastrarUsuarioRequestDTO, Usuario>();
                cfg.CreateMap<CadastrarAreaConhecimentoRequestDTO, AreaConhecimento>();
                cfg.CreateMap<CadastrarTipoPublicacaoRequestDTO, TipoPublicacao>();
                cfg.CreateMap<CadastrarUsuarioRequestDTO, Usuario>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
