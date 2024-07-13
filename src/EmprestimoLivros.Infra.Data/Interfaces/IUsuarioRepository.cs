using EmprestimoLivros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Infra.Data.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ListarUsuarios();
        Task<Usuario> BuscarUsuario(int id);
        Task CadastrarUsuario(Usuario usuario);
        Task<Usuario> BuscarUsuarioPorMatricula(string matricula);
        Task DeletarUsuario(int Id);
    }
}
