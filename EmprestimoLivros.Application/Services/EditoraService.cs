using AutoMapper;
using EmprestimoLivros.Application.DTOs.Editora.Request;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Application.Validator;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Interfaces;

namespace EmprestimoLivros.Application.Services
{
    public class EditoraService : IEditoraService
    {
        private readonly IMapper _mapper;
        private readonly IEditoraRepository _editoraRepository;
        private readonly EditoraValidator _validator;

        public EditoraService(IMapper mapper, IEditoraRepository editoraRepository, EditoraValidator validator)
        {
            _mapper = mapper;
            _editoraRepository = editoraRepository;
            _validator = validator;
        }

        public async Task<Editora> BuscarEditora(int id)
        {
            await _validator.BuscarEditora(id);

            return await _editoraRepository.BuscarEditora(id);
        }

        public async Task CadastrarEditora(CadastrarEditoraRequestDTO editoraDTO)
        {
            var editora = await Task.Run(() => _mapper.Map<Editora>(editoraDTO));

            if (editora == null)
                throw new Exception("Erro ao cadastrar carteira");

            await _editoraRepository.CadastrarEditora(editora);
        }

        public async Task<IEnumerable<Editora>> ListarEditoras()
        {
            throw new NotImplementedException();
        }
    }
}
