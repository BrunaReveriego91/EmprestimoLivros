using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Infra.Data.Interfaces
{
    public interface ITituloRepository
    {
        Task<IEnumerable<Titulo>> ListarTitulos();
        Task<Titulo> BuscarTitulo(int id);
        Task CadastrarTitulo(Titulo titulo);
        Task RemoverTitulo(int id);
    }
}
