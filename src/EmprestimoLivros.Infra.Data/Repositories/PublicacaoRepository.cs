using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Context;
using EmprestimoLivros.Infra.Data.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Infra.Data.Repositories
{
    public class PublicacaoRepository : IPublicacaoRepository
    {
        private readonly IMongoContext _context;
        public PublicacaoRepository(IMongoContext context) 
        { 
            _context = context;
        }

        public Task<Publicacao> BuscarPublicacao(int id)
        {
            var filter = Builders<Publicacao>.Filter.Eq(p => p.Id, id);
            return _context.Publicacao.Find(filter).FirstOrDefaultAsync();
        }

        public Task CadastrarPublicacao(Publicacao publicacao)
        {
            return _context.Publicacao.InsertOneAsync(publicacao);
        }

        public async Task<IEnumerable<Publicacao>> ListarPublicacao()
        {
            return await _context.Publicacao.Find(_ => true).ToListAsync();
        }
    }
}
