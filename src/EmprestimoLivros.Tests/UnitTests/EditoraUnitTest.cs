using AutoMapper;
using EmprestimoLivros.Application.DTOs.Editora.Request;
using EmprestimoLivros.Application.Services;
using EmprestimoLivros.Application.Validator;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Interfaces;
using EmprestimoLivros.Tests.Fixture;
using Moq;

namespace EmprestimoLivros.Tests
{
    public class EditoraServiceTests
    {
        private readonly EditoraService _editoraService;
        private readonly Mock<IEditoraRepository> _mockEditoraRepository = new Mock<IEditoraRepository>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly EditoraValidator _validator = new EditoraValidator(); 

        public EditoraServiceTests()
        {
            _editoraService = new EditoraService(_mockMapper.Object, _mockEditoraRepository.Object, _validator);
        }

        [Fact]
        public async Task BuscarEditora_DeveRetornarEditoraExistente()
        {
            // Arrange
            int id = 1;
            var mockEditora = EditoraFaker.GerarEditoraFake(1).FirstOrDefault();
            _mockEditoraRepository.Setup(repo => repo.BuscarEditora(id)).ReturnsAsync(mockEditora);

            // Act
            var result = await _editoraService.BuscarEditora(id);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task BuscarEditora_DeveRetornarNullQuandoNaoExistir()
        {
            // Arrange
            int id = 1;
            _mockEditoraRepository.Setup(repo => repo.BuscarEditora(id)).ReturnsAsync((Editora)null);

            // Act
            var result = await _editoraService.BuscarEditora(id);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CadastrarEditora_DeveLancarException()
        {
            // Arrange
            var editoraDTO = new CadastrarEditoraRequestDTO { Id = 1, Nome = "Nova Editora" };
            _mockEditoraRepository.Setup(repo => repo.BuscarEditora(editoraDTO.Id)).ReturnsAsync((Editora)null);

            // Act &&  Assert
            Assert.ThrowsAsync<Exception>(async () => await _editoraService.CadastrarEditora(editoraDTO));
        }

        [Fact]
        public async Task CadastrarEditora_DeveLancarExcecaoQuandoIdJaExistir()
        {
            // Arrange
            var editoraDTO = new CadastrarEditoraRequestDTO { Id = 1, Nome = "Nova Editora" };
            var editora = EditoraFaker.GerarEditoraFake().FirstOrDefault();
            _mockEditoraRepository.Setup(repo => repo.BuscarEditora(editoraDTO.Id)).ReturnsAsync(editora);

            // Act
            Func<Task> act = async () => await _editoraService.CadastrarEditora(editoraDTO);

            // Assert
            await Assert.ThrowsAsync<Exception>(act);
            _mockEditoraRepository.Verify(repo => repo.CadastrarEditora(It.IsAny<Editora>()), Times.Never);
        }

        [Fact]
        public async Task AlterarEditora_DeveAlterarEditoraExistente()
        {
            // Arrange
            var editoraDTO = new AlterarEditoraRequestDTO { Id = 1, Nome = "Editora Alterada" };
            var existingEditora = new Editora { Id = editoraDTO.Id, Nome = "Editora Existente" };
            _mockEditoraRepository.Setup(repo => repo.BuscarEditora(editoraDTO.Id)).ReturnsAsync(existingEditora);

            // Act
            await _editoraService.AlterarEditora(editoraDTO);

            // Assert
            _mockEditoraRepository.Verify(repo => repo.AlterarEditora(It.IsAny<Editora>()), Times.Once);
        }

        [Fact]
        public async Task AlterarEditora_DeveLancarExcecaoQuandoEditoraNaoExistir()
        {
            // Arrange
            var editoraDTO = new AlterarEditoraRequestDTO { Id = 1, Nome = "Editora Alterada" };
            _mockEditoraRepository.Setup(repo => repo.BuscarEditora(editoraDTO.Id)).ReturnsAsync((Editora)null);

            // Act
            Func<Task> act = async () => await _editoraService.AlterarEditora(editoraDTO);

            // Assert
            await Assert.ThrowsAsync<Exception>(act);
            _mockEditoraRepository.Verify(repo => repo.AlterarEditora(It.IsAny<Editora>()), Times.Never);
        }

        [Fact]
        public async Task RemoverEditora_DeveRemoverEditoraExistente()
        {
            // Arrange
            int id = 1;
            var existingEditora = new Editora { Id = id, Nome = "Editora Existente" };
            _mockEditoraRepository.Setup(repo => repo.BuscarEditora(id)).ReturnsAsync(existingEditora);

            // Act
            await _editoraService.RemoverEditora(id);

            // Assert
            _mockEditoraRepository.Verify(repo => repo.RemoverEditora(id), Times.Once);
        }

        [Fact]
        public async Task RemoverEditora_DeveLancarExcecaoQuandoEditoraNaoExistir()
        {
            // Arrange
            int id = 1;
            _mockEditoraRepository.Setup(repo => repo.BuscarEditora(id)).ReturnsAsync((Editora)null);

            // Act
            Func<Task> act = async () => await _editoraService.RemoverEditora(id);

            // Assert
            await Assert.ThrowsAsync<Exception>(act);
            _mockEditoraRepository.Verify(repo => repo.RemoverEditora(id), Times.Never);
        }

        [Fact]
        public async Task ListarEditoras_DeveRetornarListaDeEditoras()
        {
            // Arrange
            var editoras = new List<Editora>
            {
                new Editora { Id = 1, Nome = "Editora 1" },
                new Editora { Id = 2, Nome = "Editora 2" },
                new Editora { Id = 3, Nome = "Editora 3" }
            };
            _mockEditoraRepository.Setup(repo => repo.ListarEditoras()).ReturnsAsync(editoras);

            // Act
            var result = await _editoraService.ListarEditoras();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(editoras.Count, result.Count());
            foreach (var editora in editoras)
            {
                Assert.Contains(result, e => e.Id == editora.Id && e.Nome == editora.Nome);
            }
        }
    }
}
