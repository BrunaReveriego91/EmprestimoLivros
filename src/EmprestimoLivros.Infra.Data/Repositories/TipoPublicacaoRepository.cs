using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Context;
using EmprestimoLivros.Infra.Data.Interfaces;
using MongoDB.Driver;

namespace EmprestimoLivros.Infra.Data.Repositories
{
    public class TipoPublicacaoRepository : ITipoPublicacaoRepository
    {
        private readonly IMongoContext _context;
        public TipoPublicacaoRepository(IMongoContext context)
        {
            _context = context;
        }

        public async Task<TipoPublicacao> BuscarTipoPublicacao(string tipoPublicacao)
        {
            var filter = Builders<TipoPublicacao>.Filter.Eq(t => t.Nome, tipoPublicacao);                
            return await _context.TipoPublicacao.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<TipoPublicacao> BuscarTipoPublicacaoPorId(int id)
        {
            var filter = Builders<TipoPublicacao>.Filter.Eq(e => e.Id, id);
            var editora = await _context.TipoPublicacao.Find(filter).FirstOrDefaultAsync();

            return editora;
        }

        public Task CadastrarTipoPublicacao(TipoPublicacao tipoPublicacao)
        {
            return _context.TipoPublicacao.InsertOneAsync(tipoPublicacao);
        }

        public async Task<IEnumerable<TipoPublicacao>> ListarTipoPublicacao()
        {
            return await _context.TipoPublicacao.Find(_ => true).ToListAsync();
        }

        public Task RemoverTipoPublicacao(int id)
        {
            return _context.TipoPublicacao.FindOneAndDeleteAsync(e => e.Id == id);
        }
    }
}
