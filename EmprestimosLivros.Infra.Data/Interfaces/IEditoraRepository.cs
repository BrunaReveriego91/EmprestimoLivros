using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Infra.Data.Interfaces
{
    public interface IEditoraRepository
    {
        Task<IEnumerable<Editora>> ListarEditoras();
        Task CadastrarEditora(Editora editora);
    }
}
