using AutoMapper;
using EmprestimoLivros.Application.DTOs.Publicacao.Request;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Application.Services;
using EmprestimoLivros.Application.Validator;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Interfaces;
using Moq;

namespace EmprestimoLivros.Tests
{
    public class PublicacaoServiceTests
    {
        private readonly PublicacaoService _publicacaoService;
        private readonly Mock<IPublicacaoRepository> _mockPublicacaoRepository = new Mock<IPublicacaoRepository>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly PublicacaoValidator _validator = new PublicacaoValidator();
        private readonly Mock<IEditoraService> _mockEditoraService = new Mock<IEditoraService>();
        private readonly Mock<IAreaConhecimentoService> _mockAreaConhecimentoService = new Mock<IAreaConhecimentoService>();
        private readonly Mock<ITipoPublicacaoService> _mockTipoPublicacaoService = new Mock<ITipoPublicacaoService>();

        public PublicacaoServiceTests()
        {
            _publicacaoService = new PublicacaoService(
                _mockMapper.Object,
                _mockPublicacaoRepository.Object,
                _mockEditoraService.Object,
                _mockAreaConhecimentoService.Object,
                _mockTipoPublicacaoService.Object,
                _validator
            );
        }

        [Fact]
        public async Task BuscarPublicacao_DeveRetornarPublicacao_QuandoIdValido()
        {
            // Arrange
            int validId = 1;
            var publicacao = new Publicacao();
            _mockPublicacaoRepository.Setup(repo => repo.BuscarPublicacao(validId))
                .ReturnsAsync(publicacao);

            // Act
            var result = await _publicacaoService.BuscarPublicacao(validId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(publicacao, result);
        }
        [Fact]
        public async Task BuscarPublicacao_DeveRetornarNullQuandoIdInvalido()
        {
            // Arrange
            int id = -1; // Negative ID

            // Act
            Func<Task> act = async () => await _publicacaoService.BuscarPublicacao(id);

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(act);
        }
        [Fact]
        public async Task BuscarPublicacao_DeveLancarExcecao_QuandoIdInvalido()
        {
            // Arrange
            int invalidId = 0;

            // Act
            Func<Task> act = async () => await _publicacaoService.BuscarPublicacao(invalidId);

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(act);
        }
        [Fact]
        public async Task CadastrarPublicacao_DeveCadastrarPublicacao_ComDadosValidos()
        {
            // Arrange
            var publicacaoDto = new CadastrarPublicacaoRequestDTO();
            var tipoPublicacao = new TipoPublicacao();
            var editora = new Editora();
            var areaConhecimento = new AreaConhecimento();
            var publicacao = new Publicacao();

            _mockTipoPublicacaoService.Setup(service => service.BuscarTipoPublicacaoPorId(publicacaoDto.IdTipoPublicacao))
                .ReturnsAsync(tipoPublicacao);
            _mockEditoraService.Setup(service => service.BuscarEditora(publicacaoDto.IdEditora))
                .ReturnsAsync(editora);
            _mockAreaConhecimentoService.Setup(service => service.BuscarAreaConhecimento(publicacaoDto.IdAreaConhecimento))
                .ReturnsAsync(areaConhecimento);
            _mockMapper.Setup(mapper => mapper.Map<Publicacao>(publicacaoDto))
                .Returns(publicacao);
            _mockPublicacaoRepository.Setup(repo => repo.CadastrarPublicacao(publicacao))
                .Returns(Task.CompletedTask);

            // Act
            await _publicacaoService.CadastrarPublicacao(publicacaoDto);

            // Assert
            _mockPublicacaoRepository.Verify(repo => repo.CadastrarPublicacao(publicacao), Times.Once);
        }
        [Fact]
        public async Task CadastrarPublicacao_DeveLancarExcecao_QuandoTipoPublicacaoNaoEncontrado()
        {
            // Arrange
            var publicacaoDto = new CadastrarPublicacaoRequestDTO();
            var editora = new Editora();
            var areaConhecimento = new AreaConhecimento();

            _mockEditoraService.Setup(service => service.BuscarEditora(publicacaoDto.IdEditora))
                .ReturnsAsync(editora);
            _mockAreaConhecimentoService.Setup(service => service.BuscarAreaConhecimento(publicacaoDto.IdAreaConhecimento))
                .ReturnsAsync(areaConhecimento);
            _mockTipoPublicacaoService.Setup(service => service.BuscarTipoPublicacaoPorId(publicacaoDto.IdTipoPublicacao))
                .ReturnsAsync((TipoPublicacao)null);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await _publicacaoService.CadastrarPublicacao(publicacaoDto));
        }
    }
}
