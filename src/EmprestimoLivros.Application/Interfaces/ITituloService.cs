using EmprestimoLivros.Application.DTOs.Editora.Request;
using EmprestimoLivros.Application.DTOs.Titulo.Request;
using EmprestimoLivros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.Interfaces
{
    public interface ITituloService
    {
        Task<IEnumerable<Titulo>> ListarTitulos();
        Task<Titulo> BuscarTitulo(int id);
        Task CadastrarTitulo(CadastrarTituloRequestDTO tituloDTO);
        Task RemoverTitulo(int id);
    }
}
