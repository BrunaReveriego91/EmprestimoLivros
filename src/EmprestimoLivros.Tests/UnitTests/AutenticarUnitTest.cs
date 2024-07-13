using EmprestimoLivros.Application.Services;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Interfaces;
using EmprestimoLivros.Tests.Fixture;
using Moq;

namespace EmprestimoLivros.Tests
{
    public class AutenticarServiceTests
    {
        private readonly Mock<IAutenticarRepository> _mockAutenticacaoRepository;
        private readonly Mock<IJwtToken> _tokenJwtMock;
        private readonly AutenticarService _servicoAutenticacao;

        public AutenticarServiceTests()
        {
            _mockAutenticacaoRepository = new Mock<IAutenticarRepository>();
            _tokenJwtMock = new Mock<IJwtToken>();
            _servicoAutenticacao = new AutenticarService(_mockAutenticacaoRepository.Object, _tokenJwtMock.Object);
        }

        [Fact]
        public async Task Autenticar_DeveLancarExcecao_QuandoLoginForNulo()
        {
            // Arrange
            var dadosLogin = new UsuarioLogin { Password = "senhaValida" };

            // Act
            await Assert.ThrowsAsync<Exception>(async () => await _servicoAutenticacao.Autenticar(dadosLogin));

            // Assert
            _mockAutenticacaoRepository.Verify(repo => repo.Autenticar(It.IsAny<UsuarioLogin>()), Times.Never);
        }

        [Fact]
        public async Task Autenticar_DeveLancarExcecao_QuandoSenhaForNula()
        {
            // Arrange
            var dadosLogin = new UsuarioLogin { Login = "loginValido" };

            // Act
            Func<Task> act = async () => await _servicoAutenticacao.Autenticar(dadosLogin);

            // Assert
            await Assert.ThrowsAsync<Exception>(act);
            _mockAutenticacaoRepository.Verify(repo => repo.Autenticar(It.IsAny<UsuarioLogin>()), Times.Never);
        }

        [Fact]
        public async Task Autenticar_DeveLancarExcecao_QuandoLoginESenhaInvalidos()
        {
            // Arrange
            var dadosLogin = new UsuarioLogin { Login = "loginInvalido", Password = "senhaInvalida" };

            // Act
            Func<Task> act = async () => await _servicoAutenticacao.Autenticar(dadosLogin);

            //Assert
            await Assert.ThrowsAsync<Exception>(act);
        }

        [Fact]
        public async Task Autenticar_DeveRetornarToken_QuandoLoginESenhaValidos()
        {
            // Arrange
            var dadosLogin = AutenticarFaker.UsuariosFake[0];

            var usuario = new Usuario();
            _mockAutenticacaoRepository.Setup(repo => repo.Autenticar(dadosLogin)).ReturnsAsync(usuario);
            _tokenJwtMock.Setup(token => token.GenerateToken(usuario)).Returns("tokenGerado");

            // Act
            var token = await _servicoAutenticacao.Autenticar(dadosLogin);

            // Assert
            Assert.NotNull(token);
        }
    }
}