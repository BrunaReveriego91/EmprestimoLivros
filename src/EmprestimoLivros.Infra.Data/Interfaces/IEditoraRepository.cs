using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Infra.Data.Interfaces
{
    public interface IEditoraRepository
    {
        Task<IEnumerable<Editora>> ListarEditoras();
        Task<Editora> BuscarEditora(int id);
        Task CadastrarEditora(Editora editora);
        Task AlterarEditora(Editora editora);
        Task ExcluirEditora(int id);
    }
}
