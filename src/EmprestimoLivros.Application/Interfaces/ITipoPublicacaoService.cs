using EmprestimoLivros.Application.DTOs.TipoPublicacao.Request;
using EmprestimoLivros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.Interfaces
{
    public interface ITipoPublicacaoService
    {
        Task<IEnumerable<TipoPublicacao>> ListarTipoPublicacao();
        Task CadastrarTipoPublicacao(CadastrarTipoPublicacaoRequestDTO tipoPublicacao);
        Task<TipoPublicacao> BuscarTipoPublicacaoPorId(int id);
        Task RemoverTipoPublicacao(int id);
    }
}
