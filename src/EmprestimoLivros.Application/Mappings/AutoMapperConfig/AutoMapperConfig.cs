using AutoMapper;
using EmprestimoLivros.Application.DTOs.Autenticar;
using EmprestimoLivros.Application.DTOs.Editora.Request;
using EmprestimoLivros.Application.DTOs.Titulo.Request;
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


                cfg.CreateMap<CadastrarTituloRequestDTO, Titulo>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NomeTitulo, opt => opt.MapFrom(src => src.NomeTitulo))
                .ForMember(dest => dest.AnoLancamento, opt => opt.MapFrom(src => src.AnoLancamento))
                .ForMember(dest => dest.ISBN, opt => opt.MapFrom(src => src.ISBN))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.GeneroTitulo, opt => opt.MapFrom(src => src.GeneroTitulo));

                cfg.CreateMap<UsuarioLoginDTO, UsuarioLogin>()
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
