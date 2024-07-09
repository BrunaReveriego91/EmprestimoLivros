using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
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

            CriaCollectionSeNaoExistir<Editora>("Editoras").Wait();
            CriaCollectionSeNaoExistir<Titulo>("Titulos").Wait();
            CriaCollectionSeNaoExistir<Usuario>("Usuarios").Wait();
            CriaCollectionSeNaoExistir<TipoPublicacao>("TipoPublicacoes").Wait();
            CriaCollectionSeNaoExistir<Publicacao>("Publicacoes").Wait();
            CriaCollectionSeNaoExistir<UsuarioLogin>("UsuarioLogin").Wait();
            CriaCollectionSeNaoExistir<AreaConhecimento>("AreaConhecimento").Wait();
        }

        private async Task CriaCollectionSeNaoExistir<T>(string nomeCollection)
        {
            await Task.Run(() =>
            {
                var filter = new BsonDocument("name", nomeCollection);
                var collections = _db.ListCollections(new ListCollectionsOptions { Filter = filter });

                if (!collections.Any())
                    _db.CreateCollection(nomeCollection);
            });


        }

        public IMongoCollection<Editora> Editoras => _db.GetCollection<Editora>("Editoras");
        public IMongoCollection<Titulo> Titulos => _db.GetCollection<Titulo>("Titulos");
        public IMongoCollection<Usuario> Usuarios => _db.GetCollection<Usuario>("Usuarios");
        public IMongoCollection<TipoPublicacao> TipoPublicacao => _db.GetCollection<TipoPublicacao>("TipoPublicacoes");
        public IMongoCollection<Publicacao> Publicacao => _db.GetCollection<Publicacao>("Publicacoes");
        public IMongoCollection<UsuarioLogin> UsuarioLogin => _db.GetCollection<UsuarioLogin>("UsuarioLogin");
        public IMongoCollection<AreaConhecimento> AreaConhecimento => _db.GetCollection<AreaConhecimento>("AreaConhecimento");
    }
}
