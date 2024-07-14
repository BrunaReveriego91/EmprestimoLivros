using EmprestimoLivros.Application.DTOs.Usuario.Request;
using EmprestimoLivros.Application.DTOs.Usuario.Response;
using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<BuscarUsuarioResponseDto>> ListarUsuarios();
        Task<BuscarUsuarioResponseDto> BuscarUsuario(int id);
        Task CadastrarUsuario(CadastrarUsuarioRequestDTO usuarioDTO);
        Task<Usuario> BuscarUsuarioPorMatricula(string matricula);
        Task DeletarUsuario(int Id);
    }
}
