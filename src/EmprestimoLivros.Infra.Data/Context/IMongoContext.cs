using EmprestimoLivros.Domain.Entities;
using MongoDB.Driver;

namespace EmprestimoLivros.Infra.Data.Context
{
    public interface IMongoContext
    {
        IMongoCollection<Editora> Editoras { get; }

        IMongoCollection<Titulo> Titulos { get; }

        IMongoCollection<Usuario> Usuarios { get; }
        IMongoCollection<TipoPublicacao> TipoPublicacao { get; }
        IMongoCollection<Publicacao> Publicacao { get; }
        IMongoCollection<UsuarioLogin> UsuarioLogin { get; }
        IMongoCollection<AreaConhecimento> AreaConhecimento { get; }
        IMongoCollection<Emprestimo> Emprestimo { get; }
    }
}
