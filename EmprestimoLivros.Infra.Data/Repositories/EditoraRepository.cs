using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Context;
using EmprestimoLivros.Infra.Data.Interfaces;
using MongoDB.Bson;
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

        public Task<IEnumerable<Editora>> ListarEditoras()
        {
            throw new NotImplementedException();
        }
    }
}
