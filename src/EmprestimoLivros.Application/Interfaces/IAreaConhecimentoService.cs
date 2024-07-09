using EmprestimoLivros.Application.DTOs.AreaConhecimento.Request;
using EmprestimoLivros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.Interfaces
{
    public interface IAreaConhecimentoService
    {
        Task<IEnumerable<AreaConhecimento>> ListarTodasAreas();
        Task<AreaConhecimento> BuscarAreaConhecimento(int Id);
        Task CadastrarAreaConheicmento(CadastrarAreaConhecimentoRequestDTO areaConhecimento);
        Task RemoverAreaConhecimento(int Id);
    }
}
