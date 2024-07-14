using AutoMapper;
using EmprestimoLivros.Application.DTOs.Emprestimo.Request;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Application.Services;
using EmprestimoLivros.Application.Validator;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Interfaces;
using Moq;

namespace EmprestimoLivros.Tests
{
    public class EmprestimoServiceTests
    {
        private readonly EmprestimoService _emprestimoService;
        private readonly Mock<IEmprestimoRepository> _mockEmprestimoRepository = new Mock<IEmprestimoRepository>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly EmprestimoValidator _validator = new EmprestimoValidator();
        private readonly Mock<IUsuarioService> _mockUsuarioService = new Mock<IUsuarioService>();
        private readonly Mock<IPublicacaoService> _mockPublicacaoService = new Mock<IPublicacaoService>();

        public EmprestimoServiceTests()
        {
            _emprestimoService = new EmprestimoService(
                _mockMapper.Object,
                _mockEmprestimoRepository.Object,
                _validator,
                _mockUsuarioService.Object,
                _mockPublicacaoService.Object
            );
        }

        [Fact]
        public async Task BuscarEmprestimosPorIdPublicacao_DeveRetornarListaDeEmprestimos()
        {
            // Arrange
            int idPublicacao = 1;
            var emprestimos = new List<Emprestimo>() { new Emprestimo(), new Emprestimo() };
            _mockEmprestimoRepository.Setup(repo => repo.BuscarEmprestimosPorIdPublicacao(idPublicacao))
                .ReturnsAsync(emprestimos);

            // Act
            var result = await _emprestimoService.BuscarEmprestimosPorIdPublicacao(idPublicacao);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(emprestimos.Count, result.Count());
        }
        [Fact]
        public async Task CadastrarEmprestimo_DeveCadastrarNovoEmprestimo()
        {
            // Arrange
            var emprestimoDTO = new CadastrarEmprestimoRequestDTO { IdPublicacao = 1, Matricula = "matricula" };
            var usuario = new Usuario();
            var publicacao = new Publicacao();
            _mockEmprestimoRepository.Setup(repo => repo.BuscarEmprestimosPorIdPublicacao(emprestimoDTO.IdPublicacao))
                .ReturnsAsync(Enumerable.Empty<Emprestimo>());
            _mockUsuarioService.Setup(service => service.BuscarUsuarioPorMatricula(emprestimoDTO.Matricula))
                .ReturnsAsync(usuario);
            _mockPublicacaoService.Setup(service => service.BuscarPublicacao(emprestimoDTO.IdPublicacao))
                .ReturnsAsync(publicacao);
            _mockMapper.Setup(mapper => mapper.Map<Emprestimo>(emprestimoDTO))
                .Returns(new Emprestimo());

            // Act
            await _emprestimoService.CadastrarEmprestimo(emprestimoDTO);

            // Assert
            _mockEmprestimoRepository.Verify(repo => repo.CadastrarEmprestimo(It.IsAny<Emprestimo>()), Times.Once);
        }
        [Fact]
        public async Task AtualizarDevolucaoEmprestimo_DeveAtualizarDevolucaoComSucesso()
        {
            // Arrange
            int idEmprestimo = 1;
            _mockEmprestimoRepository.Setup(repo => repo.AtualizarDevolucaoEmprestimo(idEmprestimo))
                .Returns(Task.CompletedTask);

            _mockEmprestimoRepository.Setup(x => x.BuscarEmprestimoPorIdEmprestimo(idEmprestimo)).ReturnsAsync(new Emprestimo());
            // Act
            await _emprestimoService.AtualizarDevolucaoEmprestimo(idEmprestimo);

            // Assert
            _mockEmprestimoRepository.Verify(repo => repo.AtualizarDevolucaoEmprestimo(idEmprestimo), Times.Once);
        }
        [Fact]
        public async Task CadastrarEmprestimo_DeveLancarExcecao_QuandoPublicacaoJaEstaEmprestada()
        {
            // Arrange
            var emprestimoDTO = new CadastrarEmprestimoRequestDTO { IdPublicacao = 1, Matricula = "matricula" };
            var existingEmprestimo = new Emprestimo { FoiDevolvido = false };
            _mockEmprestimoRepository.Setup(repo => repo.BuscarEmprestimosPorIdPublicacao(emprestimoDTO.IdPublicacao))
                .ReturnsAsync(new List<Emprestimo>() { existingEmprestimo });

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await _emprestimoService.CadastrarEmprestimo(emprestimoDTO));
        }
        [Fact]
        public async Task CadastrarEmprestimo_DeveLancarExcecao_QuandoUsuarioNaoEncontrado()
        {
            // Arrange
            var emprestimoDTO = new CadastrarEmprestimoRequestDTO { IdPublicacao = 1, Matricula = "matricula" };
            var publicacao = new Publicacao();
            _mockEmprestimoRepository.Setup(repo => repo.BuscarEmprestimosPorIdPublicacao(emprestimoDTO.IdPublicacao))
                .ReturnsAsync(Enumerable.Empty<Emprestimo>());
            _mockPublicacaoService.Setup(service => service.BuscarPublicacao(emprestimoDTO.IdPublicacao))
                .ReturnsAsync(publicacao);
            _mockUsuarioService.Setup(service => service.BuscarUsuarioPorMatricula(emprestimoDTO.Matricula))
                .ReturnsAsync((Usuario)null);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await _emprestimoService.CadastrarEmprestimo(emprestimoDTO));
        }
    }
}
