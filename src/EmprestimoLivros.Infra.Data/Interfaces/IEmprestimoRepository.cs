using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Infra.Data.Interfaces
{
    public interface IEmprestimoRepository
    {
        Task<IEnumerable<Emprestimo>> BuscarEmprestimosPorIdPublicacao(int idPublicacao);
        Task<Emprestimo> BuscarEmprestimoPorIdEmprestimo(int idEmprestimo);
        Task AtualizarDevolucaoEmprestimo(int idEmprestimo);
        Task CadastrarEmprestimo(Emprestimo emprestimo);
        Task<IEnumerable<Emprestimo>> ListarEmprestimos();
        Task DeletarEmprestimo(int idEmprestimo);
    }
}
