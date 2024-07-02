using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EmprestimoLivros.Infra.Data.Context
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase _db;
        public MongoContext(IOptions<MongoConfiguration> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            _db = client.GetDatabase(config.Value.Database);
        }

        public IMongoCollection<Editora> Editoras => _db.GetCollection<Editora>("Editoras");
    }
}
