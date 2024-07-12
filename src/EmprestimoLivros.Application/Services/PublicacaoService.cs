using AutoMapper;
using EmprestimoLivros.Application.DTOs.Publicacao.Request;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Application.Validator;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Interfaces;

namespace EmprestimoLivros.Application.Services
{
    public class PublicacaoService : IPublicacaoService
    {
        private readonly IMapper _mapper;
        private readonly IEditoraService _editoraService;
        private readonly IAreaConhecimentoService _areaConhecimentoService;
        private readonly ITipoPublicacaoService _tipoPublicacaoService;
        private readonly IPublicacaoRepository _publicacaoRepository;
        private readonly PublicacaoValidator _publicacaoValidator;

        public PublicacaoService(IMapper mapper, IPublicacaoRepository publicacaoRepository, IEditoraService editoraService, IAreaConhecimentoService areaConhecimentoService, ITipoPublicacaoService tipoPublicacaoService, PublicacaoValidator publicacaoValidator)
        {
            _mapper = mapper;
            _publicacaoRepository = publicacaoRepository;
            _editoraService = editoraService;
            _areaConhecimentoService = areaConhecimentoService;
            _tipoPublicacaoService = tipoPublicacaoService;
            _publicacaoValidator = publicacaoValidator;
        }

        public async Task<Publicacao> BuscarPublicacao(int id)
        {
            await _publicacaoValidator.ValidaId(id);

            return await _publicacaoRepository.BuscarPublicacao(id);
        }

        public async Task CadastrarPublicacao(CadastrarPublicacaoRequestDTO publicacao)
        {
            var tipoPublicacao = await _tipoPublicacaoService.BuscarTipoPublicacaoPorId(publicacao.IdTipoPublicacao);

            if (tipoPublicacao == null)
                throw new Exception("Tipo publicação não cadastrada.");

            var editora = await _editoraService.BuscarEditora(publicacao.IdEditora);

            if (editora == null)
                throw new Exception("Editora não cadastrada.");

            var areaConhecimento = await _areaConhecimentoService.BuscarAreaConhecimento(publicacao.IdAreaConhecimento);

            if (areaConhecimento == null)
                throw new Exception("Area conhecimento não cadastrada.");


            var pub = _mapper.Map<Publicacao>(publicacao);

            pub.TipoPublicacao = tipoPublicacao;
            pub.Editora = editora;
            pub.AreaConhecimento = areaConhecimento;

            await _publicacaoRepository.CadastrarPublicacao(pub);
        }

        public async Task<IEnumerable<Publicacao>> ListarPublicacao()
        {
            return await _publicacaoRepository.ListarPublicacao();
        }

        public async Task RemoverPublicacao(int id)
        {
            await _publicacaoRepository.RemoverPublicacao(id);
        }
    }
}
