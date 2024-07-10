using EmprestimoLivros.Application.DTOs.Emprestimo.Request;
using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Application.Interfaces
{
    public interface IEmprestimoService
    {
        Task<IEnumerable<Emprestimo>> BuscarEmprestimosPorIdPublicacao(int idPublicacao);
        Task AtualizarDevolucaoEmprestimo(int idEmprestimo);
        Task CadastrarEmprestimo(CadastrarEmprestimoRequestDTO emprestimo);
        Task<IEnumerable<Emprestimo>> ListarEmprestimos();
    }
}
