using AutoMapper;
using EmprestimoLivros.Application.DTOs.TipoPublicacao.Request;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Application.Services;
using EmprestimoLivros.Application.Validator;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Interfaces;
using Moq;

namespace EmprestimoLivros.Tests
{
    public class TipoPublicacaoUnitTest
    {
        private readonly TipoPublicacaoService _tipoPublicacaoService;
        private readonly Mock<ITipoPublicacaoRepository> _mockTipoPublicacaoRepository = new Mock<ITipoPublicacaoRepository>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly TipoPublicacaoValidator _validator = new TipoPublicacaoValidator();
       
        public TipoPublicacaoUnitTest()
        {
            _tipoPublicacaoService = new TipoPublicacaoService(
                _mockTipoPublicacaoRepository.Object,
                _mockMapper.Object,
                _validator
            );
        }
        [Fact]
        public async Task BuscarTipoPublicacaoPorId_DeveRetornarTipoPublicacao_QuandoIdValido()
        {
            // Arrange
            int validId = 1;
            var tipoPublicacao = new TipoPublicacao();
            _mockTipoPublicacaoRepository.Setup(repo => repo.BuscarTipoPublicacaoPorId(validId))
                .ReturnsAsync(tipoPublicacao);

            // Act
            var result = await _tipoPublicacaoService.BuscarTipoPublicacaoPorId(validId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(tipoPublicacao, result);
        }
        [Fact]
        public async Task BuscarTipoPublicacaoPorId_DeveRetornarNullQuandoIdInvalido()
        {
            // Arrange
            int id = -1; // Negative ID

            // Act
            Func<Task> act = async () => await _tipoPublicacaoService.BuscarTipoPublicacaoPorId(id);

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(act);
        }
        [Fact]
        public async Task BuscarTipoPublicacaoPorId_DeveLancarExcecao_QuandoIdInvalido()
        {
            // Arrange
            int invalidId = 0;

            // Act
            Func<Task> act = async () => await _tipoPublicacaoService.BuscarTipoPublicacaoPorId(invalidId);

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(act);
        }
        [Fact]
        public async Task CadastrarTipoPublicacao_DeveCadastrarTipoPublicacao_ComDadosValidos()
        {
            // Arrange
            var tipoPublicacaoDto = new CadastrarTipoPublicacaoRequestDTO();
            var tipoPublicacao = new TipoPublicacao();
            _mockMapper.Setup(mapper => mapper.Map<TipoPublicacao>(tipoPublicacaoDto))
                .Returns(tipoPublicacao);
            _mockTipoPublicacaoRepository.Setup(repo => repo.CadastrarTipoPublicacao(tipoPublicacao))
                .Returns(Task.CompletedTask);

            // Act
            await _tipoPublicacaoService.CadastrarTipoPublicacao(tipoPublicacaoDto);

            // Assert
            _mockTipoPublicacaoRepository.Verify(repo => repo.CadastrarTipoPublicacao(tipoPublicacao), Times.Once);
        }
        [Fact]
        public async Task ListarTipoPublicacao_DeveRetornarListaDeTiposPublicacao()
        {
            // Arrange
            var tiposPublicacao = new List<TipoPublicacao>() { new TipoPublicacao(), new TipoPublicacao() };
            _mockTipoPublicacaoRepository.Setup(repo => repo.ListarTipoPublicacao())
                .ReturnsAsync(tiposPublicacao);

            // Act
            var result = await _tipoPublicacaoService.ListarTipoPublicacao();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(tiposPublicacao.Count, result.Count());
        }
        [Fact]
        public async Task RemoverTipoPublicacao_DeveRemoverTipoPublicacao_ComIdValido()
        {
            // Arrange
            int id = 1;

            // Act
            await _tipoPublicacaoService.RemoverTipoPublicacao(id);

            // Assert
            _mockTipoPublicacaoRepository.Verify(repo => repo.RemoverTipoPublicacao(id), Times.Once);
        }

    }
}
