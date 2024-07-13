using EmprestimosLivros.API;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace EmprestimoLivros.Tests.IntegrationTests
{
    public class EditoraIntegrationTest : IntegrationTestBase
    {
        public EditoraIntegrationTest(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Theory]
        [InlineData("/Editora")]
        public async Task ListarEditorasDeveRetornarHttpStatusOK(string url)
        {
            // Arrange
            var token = await ObterTokenAutenticacaoAsync();
            DefinirAutenticacaoHeader(token);

            //Arrange & Act
            var response = await _httpClient.GetAsync(url);

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK);
            await DeletarAdminAsync(token);
        }

        [Theory]
        [InlineData("/Editora/{id}")]
        public async Task BuscarEditoraPorIdDeveRetornarHttpStatusOK(string url)
        {
            // Arrange
            var token = await ObterTokenAutenticacaoAsync();
            DefinirAutenticacaoHeader(token);

            //Arrange & Act
            var id = "1";

            var response = await _httpClient.GetAsync(url.Replace("{id}", id));

            // Assert
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK);
            }
            await DeletarAdminAsync(token);
        }

        [Theory]
        [InlineData("/Editora/{id}")]
        public async Task BuscarEditoraPorIdDeveRetornarBadRequest(string url)
        {
            // Arrange
            var token = await ObterTokenAutenticacaoAsync();
            DefinirAutenticacaoHeader(token);

            //Arrange & Act
            var id = "-1";

            var response = await _httpClient.GetAsync(url.Replace("{id}", id));

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            await DeletarAdminAsync(token);
        }
    }
}
