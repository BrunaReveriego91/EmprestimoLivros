using AutoMapper;
using EmprestimoLivros.Application.DTOs.Emprestimo.Request;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Application.Validator;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Interfaces;

namespace EmprestimoLivros.Application.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IMapper _mapper;
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IPublicacaoService _publicacaoService;
        private readonly EmprestimoValidator _validator;

        public EmprestimoService(IMapper mapper, IEmprestimoRepository emprestimoRepository, EmprestimoValidator validator, IUsuarioService usuarioService, IPublicacaoService publicacaoService)
        {
            _mapper = mapper;
            _emprestimoRepository = emprestimoRepository;
            _validator = validator;
            _usuarioService = usuarioService;
            _publicacaoService = publicacaoService;
        }

        public async Task AtualizarDevolucaoEmprestimo(int idEmprestimo)
        {
            await _emprestimoRepository.AtualizarDevolucaoEmprestimo(idEmprestimo);
        }

        public async Task<IEnumerable<Emprestimo>> BuscarEmprestimosPorIdPublicacao(int idPublicacao)
        {
            return await _emprestimoRepository.BuscarEmprestimosPorIdPublicacao(idPublicacao);


        }

        public async Task CadastrarEmprestimo(CadastrarEmprestimoRequestDTO emprestimo)
        {
            var emprestimos = await BuscarEmprestimosPorIdPublicacao(emprestimo.IdPublicacao);

            if (emprestimos != null && emprestimos.Any())
            {
                var ultimoEmprestimo = emprestimos.FirstOrDefault();

                if (ultimoEmprestimo != null && !ultimoEmprestimo.FoiDevolvido)
                    throw new Exception("Publicação não disponível para empréstimo.");
            }

            var usuario = await _usuarioService.BuscarUsuarioPorMatricula(emprestimo.Matricula);

            if (usuario == null)
                throw new Exception("Não foi possível realizar o cadastro do empréstimo, usuário não localizado.");

            var publicacao = await _publicacaoService.BuscarPublicacao(emprestimo.IdPublicacao);

            if (publicacao == null)
                throw new Exception("Não foi possível realizar o cadastro do empréstimo, publicação não localizada.");

            var emprestimoMap = await Task.Run(() => _mapper.Map<Emprestimo>(emprestimo));

            emprestimoMap.Usuario = usuario;
            emprestimoMap.Publicacao = publicacao;
            emprestimoMap.FoiDevolvido = false;

            await _emprestimoRepository.CadastrarEmprestimo(emprestimoMap);

        }

        public async Task<IEnumerable<Emprestimo>> ListarEmprestimos()
        {
            return await _emprestimoRepository.ListarEmprestimos();
        }
    }
}
