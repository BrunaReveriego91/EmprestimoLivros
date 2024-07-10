using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Context;
using EmprestimoLivros.Infra.Data.Interfaces;
using MongoDB.Driver;

namespace EmprestimoLivros.Infra.Data.Repositories
{
    public class AutenticarRepository : IAutenticarRepository
    {
        private readonly IMongoContext _context;
        public AutenticarRepository(IMongoContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Autenticar(UsuarioLogin usuarioLogin)
        {
            var builder = Builders<Usuario>.Filter;
            var filter = builder.Eq(e => e.Login, usuarioLogin.Login) & builder.Eq(e => e.Password, usuarioLogin.Password);            
            return await _context.Usuarios.Find(filter).FirstAsync(); 
        }
    }
}
