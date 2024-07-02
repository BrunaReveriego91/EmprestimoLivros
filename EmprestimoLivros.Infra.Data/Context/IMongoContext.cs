using EmprestimoLivros.Domain.Entities;
using MongoDB.Driver;

namespace EmprestimoLivros.Infra.Data.Context
{
    public interface IMongoContext
    {
        IMongoCollection<Editora> Editoras { get; }
    }
}
