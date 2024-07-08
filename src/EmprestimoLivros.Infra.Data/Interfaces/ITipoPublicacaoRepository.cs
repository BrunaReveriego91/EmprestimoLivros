using EmprestimoLivros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Infra.Data.Interfaces
{
    public interface ITipoPublicacaoRepository
    {
        Task<IEnumerable<TipoPublicacao>> ListarTipoPublicacao();
        Task CadastrarTipoPublicacao(TipoPublicacao tipoPublicacao);
        Task<TipoPublicacao> BuscarTipoPublicacao(string tipoPublicacao);
    }
}
