using AutoMapper;
using EmprestimoLivros.Application.DTOs.TipoPublicacao.Request;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Interfaces;

namespace EmprestimoLivros.Application.Services
{
    public class TipoPublicacaoService : ITipoPublicacaoService
    {
        private readonly IMapper _mapper;
        private readonly ITipoPublicacaoRepository _tipoPublicacaoRepository;
        public TipoPublicacaoService(ITipoPublicacaoRepository tipoPublicacaoRepository, IMapper mapper)
        {
            _mapper = mapper;
            _tipoPublicacaoRepository = tipoPublicacaoRepository;
        }

        public async Task<TipoPublicacao> BuscarTipoPublicacao(string tipoPublicacao)
        {
            return await _tipoPublicacaoRepository.BuscarTipoPublicacao(tipoPublicacao);
        }

        public async Task<TipoPublicacao> BuscarTipoPublicacaoPorId(int id)
        {
            return await _tipoPublicacaoRepository.BuscarTipoPublicacaoPorId(id);
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
