using EmprestimoLivros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Infra.Data.Interfaces
{
    public interface IAutenticarRepository
    {
        Task<Usuario> Autenticar(UsuarioLogin usuarioLogin);
    }
}
