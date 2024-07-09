using EmprestimoLivros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Infra.Data.Interfaces
{
    public interface IAreaConhecimentoRepository
    {
        Task<IEnumerable<AreaConhecimento>> ListarTodasAreas();
        Task<AreaConhecimento> BuscarAreaConhecimento(int Id);
        Task CadastrarAreaConheicmento(AreaConhecimento areaConhecimento);
        Task RemoverAreaConhecimento(int Id);
    }
}
