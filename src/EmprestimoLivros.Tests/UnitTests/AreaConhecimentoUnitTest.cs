using AutoMapper;
using EmprestimoLivros.Application.DTOs.AreaConhecimento.Request;
using EmprestimoLivros.Application.Services;
using EmprestimoLivros.Application.Validator;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Interfaces;
using EmprestimoLivros.Tests.Fixture;
using Moq;

namespace EmprestimoLivros.Tests
{
    public class AreaConhecimentoServiceTests
    {
        private readonly AreaConhecimentoService _areaConhecimentoService;
        private readonly Mock<IAreaConhecimentoRepository> _mockAreaConhecimentoRepository = new Mock<IAreaConhecimentoRepository>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly AreaConhecimentoValidator _validator = new AreaConhecimentoValidator(); 

        public AreaConhecimentoServiceTests()
        {
            _areaConhecimentoService = new AreaConhecimentoService(
                _mockAreaConhecimentoRepository.Object,
                _mockMapper.Object,
                _validator
            );
        }

        [Fact]
        public async Task BuscarAreaConhecimento_DeveRetornarAreaConhecimentoExistente()
        {
            // Arrange
            int id = 1;
            var mockAreaConhecimento = new AreaConhecimento { Id = id, NomeArea = "Área de Conhecimento" };
            _mockAreaConhecimentoRepository.Setup(repo => repo.BuscarAreaConhecimento(id)).ReturnsAsync(mockAreaConhecimento);

            // Act
            var result = await _areaConhecimentoService.BuscarAreaConhecimento(id);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task BuscarAreaConhecimento_DeveRetornarNullQuandoNaoExistir()
        {
            // Arrange
            int id = 1;
            _mockAreaConhecimentoRepository.Setup(repo => repo.BuscarAreaConhecimento(id)).ReturnsAsync((AreaConhecimento)null);

            // Act
            var result = await _areaConhecimentoService.BuscarAreaConhecimento(id);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CadastrarAreaConhecimento_DeveLancarExceptionQuandoIdJaExistir()
        {
            // Arrange
            var areaConhecimentoDTO = new CadastrarAreaConhecimentoRequestDTO { Id = 1, NomeArea = "Nova Área de Conhecimento" };
            var areaConhecimento = AreaPublicacaoFaker.GerarEditoraFake().FirstOrDefault();
            _mockAreaConhecimentoRepository.Setup(
                repo => repo.BuscarAreaConhecimento(
                    areaConhecimentoDTO.Id
                )).ReturnsAsync(areaConhecimento);

            // Act
            Func<Task> act = async () => await _areaConhecimentoService.CadastrarAreaConheicmento(areaConhecimentoDTO);

            // Assert
            await Assert.ThrowsAsync<Exception>(act);
            _mockAreaConhecimentoRepository.Verify(repo => repo.CadastrarAreaConheicmento(It.IsAny<AreaConhecimento>()), Times.Never);
        }

        [Fact]
        public async Task CadastrarAreaConhecimento_DeveCadastrarNovaAreaConhecimento()
        {
            // Arrange
            var areaConhecimentoDTO = new CadastrarAreaConhecimentoRequestDTO { NomeArea = "Nova Área de Conhecimento" };
            var areaConhecimento = new AreaConhecimento { NomeArea = "Nova Área de Conhecimento" };
            _mockMapper.Setup(m => m.Map<AreaConhecimento>(It.IsAny<CadastrarAreaConhecimentoRequestDTO>())).Returns(areaConhecimento);

            // Act
            await _areaConhecimentoService.CadastrarAreaConheicmento(areaConhecimentoDTO);

            // Assert
            _mockAreaConhecimentoRepository.Verify(repo => repo.CadastrarAreaConheicmento(It.IsAny<AreaConhecimento>()), Times.Once);
        }

        [Fact]
        public async Task RemoverAreaConhecimento_DeveRemoverAreaConhecimentoExistente()
        {
            // Arrange
            int id = 1;
            var existingAreaConhecimento = new AreaConhecimento { Id = id, NomeArea = "Área de Conhecimento Existente" };
            _mockAreaConhecimentoRepository.Setup(repo => repo.BuscarAreaConhecimento(id)).ReturnsAsync(existingAreaConhecimento);

            // Act
            await _areaConhecimentoService.RemoverAreaConhecimento(id);

            // Assert
            _mockAreaConhecimentoRepository.Verify(repo => repo.RemoverAreaConhecimento(id), Times.Once);
        }

        [Fact]
        public async Task RemoverAreaConhecimento_DeveLancarExcecaoQuandoAreaConhecimentoNaoExistir()
        {
            // Arrange
            int id = 1;
            _mockAreaConhecimentoRepository.Setup(repo => repo.BuscarAreaConhecimento(id)).ReturnsAsync((AreaConhecimento)null);

            // Act
            Func<Task> act = async () => await _areaConhecimentoService.RemoverAreaConhecimento(id);

            // Assert
            await Assert.ThrowsAsync<Exception>(act);
            _mockAreaConhecimentoRepository.Verify(repo => repo.RemoverAreaConhecimento(id), Times.Never);
        }

        [Fact]
        public async Task ListarTodasAreas_DeveRetornarListaDeAreas()
        {
            // Arrange
            var areas = new List<AreaConhecimento>
        {
            new AreaConhecimento { Id = 1, NomeArea = "Área 1" },
            new AreaConhecimento { Id = 2, NomeArea = "Área 2" },
            new AreaConhecimento { Id = 3, NomeArea = "Área 3" }
        };
            _mockAreaConhecimentoRepository.Setup(repo => repo.ListarTodasAreas()).ReturnsAsync(areas);

            // Act
            var result = await _areaConhecimentoService.ListarTodasAreas();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(areas.Count, result.Count());
            foreach (var area in areas)
            {
                Assert.Contains(result, a => a.Id == area.Id && a.NomeArea == area.NomeArea);
            }
        }
    }
}
