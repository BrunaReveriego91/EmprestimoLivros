using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Context;
using EmprestimoLivros.Infra.Data.Interfaces;

namespace EmprestimoLivros.Infra.Data.Repositories
{
    public class EditoraRepository : IEditoraRepository
    {
        private readonly IMongoContext _context;

        public EditoraRepository(IMongoContext context)
        {
            _context = context;
        }

        public async Task CadastrarEditora(Editora editora)
        {
            await _context.Editoras.InsertOneAsync(editora);
        }

        public Task<IEnumerable<Editora>> ListarEditoras()
        {
            throw new NotImplementedException();
        }
    }
}
