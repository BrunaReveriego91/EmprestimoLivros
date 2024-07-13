using AutoMapper;
using EmprestimoLivros.Application.DTOs.TipoPublicacao.Request;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Application.Validator;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Interfaces;

namespace EmprestimoLivros.Application.Services
{
    public class TipoPublicacaoService : ITipoPublicacaoService
    {
        private readonly IMapper _mapper;
        private readonly ITipoPublicacaoRepository _tipoPublicacaoRepository;
        private readonly TipoPublicacaoValidator _tipoPublicacaoValidator;

        public TipoPublicacaoService(ITipoPublicacaoRepository tipoPublicacaoRepository, IMapper mapper, TipoPublicacaoValidator tipoPublicacaoValidator)
        {
            _mapper = mapper;
            _tipoPublicacaoRepository = tipoPublicacaoRepository;
            _tipoPublicacaoValidator = tipoPublicacaoValidator;
        }

        public async Task<TipoPublicacao> BuscarTipoPublicacaoPorId(int id)
        {
            await _tipoPublicacaoValidator.ValidaId(id);

            var tipoPublicacao = await _tipoPublicacaoRepository.BuscarTipoPublicacaoPorId(id);

            if (tipoPublicacao == null)
                throw new Exception($"Tipo de publicação com o ID {id} não encontrada.");

            return tipoPublicacao;
        }

        public async Task CadastrarTipoPublicacao(CadastrarTipoPublicacaoRequestDTO tipoPublicacao)
        {
            var pub = _mapper.Map<TipoPublicacao>(tipoPublicacao);
            await _tipoPublicacaoRepository.CadastrarTipoPublicacao(pub);
        }

        public async Task<IEnumerable<TipoPublicacao>> ListarTipoPublicacao()
        {
            return await _tipoPublicacaoRepository.ListarTipoPublicacao();
        }

        public async Task RemoverTipoPublicacao(int id)
        {
            await _tipoPublicacaoRepository.RemoverTipoPublicacao(id);
        }
    }
}
