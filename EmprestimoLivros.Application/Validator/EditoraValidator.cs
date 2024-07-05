using EmprestimoLivros.Application.DTOs.Editora.Request;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Application.Validator
{
    public class EditoraValidator
    {

        public async Task BuscarEditora(int id)
        {

            await Task.Run(() =>
            {
                if (id <= 0)
                {
                    throw new Exception("Id deve ser um número válido");
                }
            });
        }

        public Task CadastrarEditora(CadastrarEditoraRequestDTO editoraDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Editora>> ListarEditoras()
        {
            throw new NotImplementedException();
        }
    }
}
