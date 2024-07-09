using AutoMapper;
using EmprestimoLivros.Application.DTOs.Publicacao.Request;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Interfaces;

namespace EmprestimoLivros.Application.Services
{
    public class PublicacaoService : IPublicacaoService
    {
        private readonly IMapper _mapper;
        private readonly IPublicacaoRepository _publicacaoRepository;
        public PublicacaoService(IMapper mapper, IPublicacaoRepository publicacaoRepository) 
        {
            _mapper = mapper;
            _publicacaoRepository = publicacaoRepository;
        }

        public Task<Publicacao> BuscarPublicacao(int id)
        {
            return _publicacaoRepository.BuscarPublicacao(id);
        }

        public Task CadastrarPublicacao(CadastrarPublicacaoRequestDTO publicacao)
        {
            var pub = _mapper.Map<Publicacao>(publicacao);
            return _publicacaoRepository.CadastrarPublicacao(pub);
        }

        public Task<IEnumerable<Publicacao>> ListarPublicacao()
        {
            return _publicacaoRepository.ListarPublicacao();
        }

        public Task RemoverPublicacao(int id)
        {
            return _publicacaoRepository.RemoverPublicacao(id);
        }
    }
}
