using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Context;
using EmprestimoLivros.Infra.Data.Interfaces;
using MongoDB.Driver;

namespace EmprestimoLivros.Infra.Data.Repositories
{
    public class TituloRepository : ITituloRepository
    {
        private readonly IMongoContext _context;

        public TituloRepository(IMongoContext context)
        {
            _context = context;
        }

        public async Task<Titulo> BuscarTitulo(int id)
        {
            try
            {
                var filter = Builders<Titulo>.Filter.Eq(e => e.Id, id);
                var editora = await _context.Titulos.Find(filter).FirstOrDefaultAsync();

                return editora;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task CadastrarTitulo(Titulo titulo)
        {
            try
            {
                await _context.Titulos.InsertOneAsync(titulo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Titulo>> ListarTitulos()
        {
            try
            {
                var titulos = await _context.Titulos.Find(_ => true).ToListAsync();

                return titulos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task RemoverTitulo(int id)
        {
            try
            {
                return _context.Titulos.FindOneAndDeleteAsync(e => e.Id == id);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
