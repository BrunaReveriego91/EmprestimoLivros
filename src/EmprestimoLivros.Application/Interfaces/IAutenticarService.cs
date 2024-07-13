using EmprestimoLivros.Application.DTOs.Autenticar;
using EmprestimoLivros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.Interfaces
{
    public interface IAutenticarService
    {
        Task<string> Autenticar(Usuario usuarioLogin);
    }
}
