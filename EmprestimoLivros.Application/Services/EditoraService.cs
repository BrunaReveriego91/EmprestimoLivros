using EmprestimoLivros.Application.DTOs.Editora.Request;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Application.Services
{
    public class EditoraService : IEditoraService
    {
        public Task CadastrarEditora(CadastrarEditoraRequestDTO editora)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Editora>> ListarEditoras()
        {
            throw new NotImplementedException();
        }
    }
}
