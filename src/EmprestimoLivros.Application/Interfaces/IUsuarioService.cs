using EmprestimoLivros.Application.DTOs.Editora.Request;
using EmprestimoLivros.Application.DTOs.Titulo.Request;
using EmprestimoLivros.Application.DTOs.Usuario.Request;
using EmprestimoLivros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> ListarUsuarios();
        Task<Usuario> BuscarUsuario(int id);
        Task CadastrarUsuario(CadastrarUsuarioRequestDTO usuarioDTO);
    }
}
