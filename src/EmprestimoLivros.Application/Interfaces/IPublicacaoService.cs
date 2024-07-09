using EmprestimoLivros.Application.DTOs.Publicacao.Request;
using EmprestimoLivros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.Interfaces
{
    public interface IPublicacaoService
    {
        Task<IEnumerable<Publicacao>> ListarPublicacao();
        Task CadastrarPublicacao(CadastrarPublicacaoRequestDTO publicacao);
        Task<Publicacao> BuscarPublicacao(int id);
        Task RemoverPublicacao(int id);
    }
}
