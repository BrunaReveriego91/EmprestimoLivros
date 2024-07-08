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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IMongoContext _context;

        public UsuarioRepository(IMongoContext context)
        {
            _context = context;
        }

        public async Task<Usuario> BuscarUsuario(int id)
        {
            try
            {
                var filter = Builders<Usuario>.Filter.Eq(e => e.Id, id);                
                return await _context.Usuarios.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Usuario> BuscarUsuarioPorMatricula(string matricula)
        {
            try
            {
                var filter = Builders<Usuario>.Filter.Eq(e => e.Matricula, matricula);
                return await _context.Usuarios.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task CadastrarUsuario(Usuario usuario)
        {
            try
            {
                await _context.Usuarios.InsertOneAsync(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Usuario>> ListarUsuarios()
        {
            try
            {
                return await _context.Usuarios.Find(_ => true).ToListAsync();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }
    }
}
