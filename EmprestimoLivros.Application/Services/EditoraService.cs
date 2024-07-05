using AutoMapper;
using EmprestimoLivros.Application.DTOs.Editora.Request;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Interfaces;

namespace EmprestimoLivros.Application.Services
{
    public class EditoraService : IEditoraService
    {
        private readonly IMapper _mapper;
        private readonly IEditoraRepository _editoraRepository;

        public EditoraService(IMapper mapper, IEditoraRepository editoraRepository)
        {
            _mapper = mapper;
            _editoraRepository = editoraRepository;
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
