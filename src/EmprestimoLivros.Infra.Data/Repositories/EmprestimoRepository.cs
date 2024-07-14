using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Context;
using EmprestimoLivros.Infra.Data.Interfaces;
using MongoDB.Driver;

namespace EmprestimoLivros.Infra.Data.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly IMongoContext _context;

        public EmprestimoRepository(IMongoContext context)
        {
            _context = context;
        }

        public async Task AtualizarDevolucaoEmprestimo(int idEmprestimo)
        {
            var filter = Builders<Emprestimo>.Filter.Eq(e => e.Id, idEmprestimo);
            var update = Builders<Emprestimo>.Update.Set(e => e.FoiDevolvido, true);
            await _context.Emprestimos.UpdateOneAsync(filter, update);
        }

        public async Task<Emprestimo> BuscarEmprestimoPorIdEmprestimo(int idEmprestimo)
        {

            try
            {
                var filter = Builders<Emprestimo>.Filter.Eq(e => e.Id, idEmprestimo);
                var emprestimo = await _context.Emprestimos.Find(filter)
               .FirstOrDefaultAsync();

                return emprestimo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Emprestimo>> BuscarEmprestimosPorIdPublicacao(int idPublicacao)
        {
            try
            {
                var filter = Builders<Emprestimo>.Filter.Eq(e => e.Publicacao.Id, idPublicacao);
                var emprestimos = await _context.Emprestimos.Find(filter)
               .SortByDescending(e => e.DataEmprestimo)
               .ToListAsync();

                return emprestimos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task CadastrarEmprestimo(Emprestimo emprestimo)
        {
            try
            {
                await _context.Emprestimos.InsertOneAsync(emprestimo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Emprestimo>> ListarEmprestimos()
        {
            try
            {
                var emprestimos = await _context.Emprestimos.Find(_ => true).ToListAsync();

                return emprestimos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
