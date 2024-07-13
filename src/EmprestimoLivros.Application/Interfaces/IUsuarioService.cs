using EmprestimoLivros.Application.DTOs.Usuario.Request;
using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> ListarUsuarios();
        Task<Usuario> BuscarUsuario(int id);
        Task CadastrarUsuario(CadastrarUsuarioRequestDTO usuarioDTO);
        Task<Usuario> BuscarUsuarioPorMatricula(string matricula);
    }
}
