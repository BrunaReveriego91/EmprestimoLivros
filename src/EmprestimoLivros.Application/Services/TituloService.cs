using AutoMapper;
using EmprestimoLivros.Application.DTOs.Titulo.Request;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Application.Validator;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Interfaces;

namespace EmprestimoLivros.Application.Services
{
    public class TituloService : ITituloService
    {
        private readonly IMapper _mapper;
        private readonly ITituloRepository _tituloRepository;
        private readonly IEditoraService _editoraService;
        private readonly TituloValidator _tituloValidator;

        public TituloService(ITituloRepository tituloRepository, TituloValidator tituloValidator, IMapper mapper, IEditoraService editoraService)
        {
            _tituloRepository = tituloRepository;
            _tituloValidator = tituloValidator;
            _mapper = mapper;
            _editoraService = editoraService;
        }

        public async Task<Titulo> BuscarTitulo(int id)
        {
            await _tituloValidator.ValidaId(id);

            return await _tituloRepository.BuscarTitulo(id);
        }

        public async Task CadastrarTitulo(CadastrarTituloRequestDTO tituloDTO)
        {
            var tituloExistente = await _tituloRepository.BuscarTitulo(tituloDTO.Id);

            if (tituloExistente != null)
                throw new Exception("Id já cadastrado.");

            var validaEditora = await _editoraService.BuscarEditora(tituloDTO.IdEditora);

            if (validaEditora == null)
                throw new Exception("Id editora inválido.");

            await _tituloValidator.ValidaEnumGeneroTitulo(tituloDTO.GeneroTitulo);

            var titulo = await Task.Run(() => _mapper.Map<Titulo>(tituloDTO));

            if (titulo == null)
                throw new Exception("Erro ao cadastrar titulo.");

            titulo.Editora = validaEditora;

            await _tituloRepository.CadastrarTitulo(titulo);
        }

        public async Task<IEnumerable<Titulo>> ListarTitulos()
        {
            return await _tituloRepository.ListarTitulos();
        }

        public Task RemoverTitulo(int id)
        {
            return _tituloRepository.RemoverTitulo(id);
        }
    }
}
