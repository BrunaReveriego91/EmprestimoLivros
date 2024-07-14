using AutoMapper;
using EmprestimoLivros.Application.DTOs.Usuario.Request;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Application.Mappings.AutoMapperConfig;
using EmprestimoLivros.Application.Services;
using EmprestimoLivros.Application.Validator;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Interfaces;
using Moq;

namespace EmprestimoLivros.Tests
{
    public class UsuarioServiceTests
    {
        private readonly UsuarioService _usuarioService;
        private readonly Mock<IUsuarioRepository> _mockusuarioRepository = new Mock<IUsuarioRepository>();
        private readonly IMapper _mapper;
        private readonly UsuarioValidator _validator = new UsuarioValidator();

        public UsuarioServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperConfig>();
            });

            _mapper = config.CreateMapper();

            _usuarioService = new UsuarioService(
                _mapper,
                _mockusuarioRepository.Object
            );
        }

        [Fact]
        public async Task BuscarUsuario_DeveRetornarUsuario_QuandoIdValido()
        {
            // Arrange
            int validId = 1;
            var usuario = new Usuario();

            _mockusuarioRepository.Setup(repo => repo.BuscarUsuario(validId))
                .ReturnsAsync(usuario);


            // Act
            var result = await _usuarioService.BuscarUsuario(validId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(usuario.Nome, result.Nome);
        }
        [Fact]
        public async Task BuscarUsuario_DeveRetornarNullQuandoIdInvalido()
        {
            // Arrange
            int id = -1;

            // Act
            Func<Task> act = async () => await _usuarioService.BuscarUsuario(id);

            // Assert
            await Assert.ThrowsAsync<Exception>(act);
        }
        [Fact]
        public async Task BuscarUsuario_DeveLancarExcecao_QuandoIdInvalido()
        {
            // Arrange
            int invalidId = 0;

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await _usuarioService.BuscarUsuario(invalidId));
        }

        [Fact]
        public async Task BuscarUsuario_DeveLancarExcecao_QuandoUsuarioNaoEncontrado()
        {
            // Arrange
            int userId = 1;
            _mockusuarioRepository.Setup(repo => repo.BuscarUsuario(userId))
                .ReturnsAsync((Usuario)null);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await _usuarioService.BuscarUsuario(userId));
        }

        [Fact]
        public async Task BuscarUsuarioPorMatricula_DeveRetornarUsuario_QuandoMatriculaValida()
        {
            // Arrange
            string validMatricula = "matricula123";
            var usuario = new Usuario();
            _mockusuarioRepository.Setup(repo => repo.BuscarUsuarioPorMatricula(validMatricula))
                .ReturnsAsync(usuario);

            // Act
            var result = await _usuarioService.BuscarUsuarioPorMatricula(validMatricula);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(usuario, result);
        }

        [Fact]
        public async Task BuscarUsuarioPorMatricula_DeveRetornarNull_QuandoMatriculaInvalida()
        {
            // Arrange
            string invalidMatricula = "";

            // Act
            var result = await _usuarioService.BuscarUsuarioPorMatricula(invalidMatricula);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CadastrarUsuario_DeveCadastrarUsuario_ComDadosValidos()
        {
            // Arrange
            var usuarioDto = new CadastrarUsuarioRequestDTO();
            var usuario = new Usuario();

            _mockusuarioRepository.Setup(repo => repo.BuscarUsuarioPorMatricula(usuarioDto.Matricula))
                .ReturnsAsync((Usuario)null);

            _mockusuarioRepository.Setup(repo => repo.CadastrarUsuario(usuario))
            .Returns(Task.CompletedTask);

            // Act
            await _usuarioService.CadastrarUsuario(usuarioDto);

            // Assert
            _mockusuarioRepository.Verify(repo => repo.CadastrarUsuario(It.IsAny<Usuario>()), Times.Once);
        }

        [Fact]
        public async Task CadastrarUsuario_DeveLancarExcecao_QuandoDadosUsuarioNulos()
        {
            // Arrange
            CadastrarUsuarioRequestDTO usuarioDto = null;

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await _usuarioService.CadastrarUsuario(usuarioDto));
        }

        [Fact]
        public async Task CadastrarUsuario_DeveLancarExcecao_QuandoUsuarioJaCadastrado()
        {
            // Arrange
            var usuarioDto = new CadastrarUsuarioRequestDTO() { Matricula = "matricula123" };
            var existingUser = new Usuario();
            _mockusuarioRepository.Setup(repo => repo.BuscarUsuarioPorMatricula(usuarioDto.Matricula))
                .ReturnsAsync(existingUser);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await _usuarioService.CadastrarUsuario(usuarioDto));
        }

        [Fact]
        public async Task ListarUsuarios_DeveRetornarListaDeUsuarios()
        {
            // Arrange
            var usuarios = new List<Usuario>() { new Usuario(), new Usuario() };
            _mockusuarioRepository.Setup(repo => repo.ListarUsuarios())
                .ReturnsAsync(usuarios);

            // Act
            var result = await _usuarioService.ListarUsuarios();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(usuarios.Count, result.Count());
        }

    }
}
