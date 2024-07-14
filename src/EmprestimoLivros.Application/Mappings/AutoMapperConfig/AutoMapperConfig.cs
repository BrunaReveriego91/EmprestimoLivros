using AutoMapper;
using EmprestimoLivros.Application.DTOs.AreaConhecimento.Request;
using EmprestimoLivros.Application.DTOs.Autenticar;
using EmprestimoLivros.Application.DTOs.Editora.Request;
using EmprestimoLivros.Application.DTOs.Emprestimo.Request;
using EmprestimoLivros.Application.DTOs.Publicacao.Request;
using EmprestimoLivros.Application.DTOs.TipoPublicacao.Request;
using EmprestimoLivros.Application.DTOs.Usuario.Request;
using EmprestimoLivros.Application.DTOs.Usuario.Response;
using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Application.Mappings.AutoMapperConfig
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            this.CreateMap<CadastrarEditoraRequestDTO, Editora>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.CNPJ, opt => opt.MapFrom(src => src.CNPJ))
              .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));

            this.CreateMap<AlterarEditoraRequestDTO, Editora>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.CNPJ, opt => opt.MapFrom(src => src.CNPJ))
              .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));

            this.CreateMap<UsuarioLoginDTO, UsuarioLogin>()
            .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            this.CreateMap<CadastrarAreaConhecimentoRequestDTO, AreaConhecimento>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.NomeArea, opt => opt.MapFrom(src => src.NomeArea));

            this.CreateMap<CadastrarPublicacaoRequestDTO, Publicacao>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
            .ForMember(dest => dest.ISBN, opt => opt.MapFrom(src => src.ISBN))
            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
            .ForMember(dest => dest.AnoDeLancamento, opt => opt.MapFrom(src => src.AnoDeLancamento));

            this.CreateMap<CadastrarTipoPublicacaoRequestDTO, TipoPublicacao>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));

            this.CreateMap<CadastrarUsuarioRequestDTO, Usuario>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(dest => dest.Matricula, opt => opt.MapFrom(src => src.Matricula))
            .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento))
            .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));

            this.CreateMap<CadastrarPublicacaoRequestDTO, Publicacao>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
              .ForMember(dest => dest.Autor, opt => opt.MapFrom(src => src.Autor))
              .ForMember(dest => dest.AnoDeLancamento, opt => opt.MapFrom(src => src.AnoDeLancamento))
              .ForMember(dest => dest.ISBN, opt => opt.MapFrom(src => src.ISBN))
              .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
              .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags));

            this.CreateMap<CadastrarUsuarioRequestDTO, Usuario>();
            this.CreateMap<CadastrarAreaConhecimentoRequestDTO, AreaConhecimento>();
            this.CreateMap<CadastrarTipoPublicacaoRequestDTO, TipoPublicacao>();
            this.CreateMap<CadastrarUsuarioRequestDTO, Usuario>();
            this.CreateMap<UsuarioLoginDTO, UsuarioLogin>();

            this.CreateMap<CadastrarEmprestimoRequestDTO, Emprestimo>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DataEmprestimo, opt => opt.MapFrom(src => src.DataEmprestimo))
            .ForMember(dest => dest.DataDevolucao, opt => opt.MapFrom(src => src.DataDevolucao));

            this.CreateMap<Usuario?, BuscarUsuarioResponseDto?>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(dest => dest.Matricula, opt => opt.MapFrom(src => src.Matricula))
            .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento))
            .ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(src => src.TipoUsuario))
            .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login));


        }
    }
}
