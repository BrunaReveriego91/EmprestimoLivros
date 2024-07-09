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
    public class AreaConhecimentoRepository : IAreaConhecimentoRepository
    {
        private readonly IMongoContext _context;
        public AreaConhecimentoRepository(IMongoContext context)
        {
            _context = context;
        }

        public Task<AreaConhecimento> BuscarAreaConhecimento(int Id)
        {
            var filter = Builders<AreaConhecimento>.Filter.Eq(a => a.Id, Id);
            return _context.AreaConhecimento.Find(filter).FirstAsync();
        }

        public Task CadastrarAreaConheicmento(AreaConhecimento areaConhecimento)
        {
            return _context.AreaConhecimento.InsertOneAsync(areaConhecimento);
        }

        public async Task<IEnumerable<AreaConhecimento>> ListarTodasAreas()
        {
            return await _context.AreaConhecimento.Find(e => true).ToListAsync();
        }
    }
}
