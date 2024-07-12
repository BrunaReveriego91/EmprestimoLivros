using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Context;
using EmprestimoLivros.Infra.Data.Interfaces;
using MongoDB.Driver;

namespace EmprestimoLivros.Infra.Data.Repositories
{
    public class AreaConhecimentoRepository : IAreaConhecimentoRepository
    {
        private readonly IMongoContext _context;
        public AreaConhecimentoRepository(IMongoContext context)
        {
            _context = context;
        }

        public async Task<AreaConhecimento> BuscarAreaConhecimento(int Id)
        {
            var filter = Builders<AreaConhecimento>.Filter.Eq(a => a.Id, Id);
            return await _context.AreaConhecimento.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CadastrarAreaConheicmento(AreaConhecimento areaConhecimento)
        {
            await _context.AreaConhecimento.InsertOneAsync(areaConhecimento);
        }

        public async Task<IEnumerable<AreaConhecimento>> ListarTodasAreas()
        {
            return await _context.AreaConhecimento.Find(e => true).ToListAsync();
        }

        public async Task RemoverAreaConhecimento(int Id)
        {
            await _context.AreaConhecimento.FindOneAndDeleteAsync(e => e.Id == Id);
        }
    }
}
