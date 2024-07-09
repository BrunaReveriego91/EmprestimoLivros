using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Context;
using EmprestimoLivros.Infra.Data.Interfaces;
using MongoDB.Driver;

namespace EmprestimoLivros.Infra.Data.Repositories
{
    public class EditoraRepository : IEditoraRepository
    {
        private readonly IMongoContext _context;

        public EditoraRepository(IMongoContext context)
        {
            _context = context;
        }

        public async Task AlterarEditora(Editora editora)
        {
            try
            {
                var filter = Builders<Editora>.Filter.Eq(e => e.Id, editora.Id);
                var update = Builders<Editora>.Update
                .Set(e => e.Nome, editora.Nome)
                    .Set(e => e.CNPJ, editora.CNPJ);

                await _context.Editoras.UpdateOneAsync(filter, update);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<Editora> BuscarEditora(int id)
        {
            try
            {
                var filter = Builders<Editora>.Filter.Eq(e => e.Id, id);
                var editora = await _context.Editoras.Find(filter).FirstOrDefaultAsync();

                return editora;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task CadastrarEditora(Editora editora)
        {
            try
            {
                await _context.Editoras.InsertOneAsync(editora);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task ExcluirEditora(int id)
        {
            try
            {
                var filter = Builders<Editora>.Filter.Eq(e => e.Id, id);
                await _context.Editoras.DeleteOneAsync(filter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Editora>> ListarEditoras()
        {
            try
            {
                var editoras = await _context.Editoras.Find(_ => true).ToListAsync();

                return editoras;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
