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

        public Task<TipoPublicacao> BuscarTipoPublicacao(string tipoPublicacao)
        {
            return _tipoPublicacaoRepository.BuscarTipoPublicacao(tipoPublicacao);
        }

        public Task CadastrarTipoPublicacao(CadastrarTipoPublicacaoRequestDTO tipoPublicacao)
        {
            var pub = _mapper.Map<TipoPublicacao>(tipoPublicacao);
            return _tipoPublicacaoRepository.CadastrarTipoPublicacao(pub);
        }

        public Task<IEnumerable<TipoPublicacao>> ListarTipoPublicacao()
        {
            return _tipoPublicacaoRepository.ListarTipoPublicacao();
        }

        public Task RemoverTipoPublicacao(int id)
        {
            return _tipoPublicacaoRepository.RemoverTipoPublicacao(id);
        }
    }
}
