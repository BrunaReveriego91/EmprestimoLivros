using AutoMapper;
using EmprestimoLivros.Application.DTOs.AreaConhecimento.Request;
using EmprestimoLivros.Application.DTOs.Autenticar;
using EmprestimoLivros.Application.DTOs.Editora.Request;
using EmprestimoLivros.Application.DTOs.Publicacao.Request;
using EmprestimoLivros.Application.DTOs.TipoPublicacao.Request;
using EmprestimoLivros.Application.DTOs.Titulo.Request;
using EmprestimoLivros.Application.DTOs.Usuario.Request;
using EmprestimoLivros.Application.DTOs.Emprestimo.Request;
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

                cfg.CreateMap<CadastrarAreaConhecimentoRequestDTO, AreaConhecimento>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NomeArea, opt => opt.MapFrom(src => src.NomeArea));

                cfg.CreateMap<CadastrarPublicacaoRequestDTO, Publicacao>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.ISBN, opt => opt.MapFrom(src => src.ISBN))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
                .ForMember(dest => dest.AnoDeLancamento, opt => opt.MapFrom(src => src.AnoDeLancamento));

                cfg.CreateMap<CadastrarTipoPublicacaoRequestDTO, TipoPublicacao>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));

                cfg.CreateMap<CadastrarUsuarioRequestDTO, Usuario>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Matricula, opt => opt.MapFrom(src => src.Matricula))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));
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
                cfg.CreateMap<UsuarioLoginDTO, UsuarioLogin>();

                cfg.CreateMap<CadastrarEmprestimoRequestDTO, Emprestimo>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DataEmprestimo, opt => opt.MapFrom(src => src.DataEmprestimo))
                .ForMember(dest => dest.DataDevolucao, opt => opt.MapFrom(src => src.DataDevolucao));
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
