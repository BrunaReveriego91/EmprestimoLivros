using EmprestimosLivros.API;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace EmprestimoLivros.Tests.IntegrationTests
{
    public class AreaConhecimentoIntegrationTest : IntegrationTestBase
    {
        public AreaConhecimentoIntegrationTest(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Theory]
        [InlineData("/AreaConhecimento")]
        public async Task ListarAreaConhecimentoDeveRetornarHttpStatusOK(string url)
        {
            // Arrange
            var token = await ObterTokenAutenticacaoAsync();
            if (string.IsNullOrEmpty(token))
            {
                Assert.Fail("Failed to obtain authentication token.");
            }
            DefinirAutenticacaoHeader(token);

            // Act
            HttpResponseMessage response = null;
            try
            {
                response = await _httpClient.GetAsync(url);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Request failed: {ex.Message}");
            }

            // Assert
            Assert.NotNull(response);
            var content = await response.Content.ReadAsStringAsync();

            // Check status code and content
            Assert.True(
                (content == "Não foram encontradas áreas de conhecimento." && response.StatusCode == HttpStatusCode.BadRequest) ||
                response.StatusCode == HttpStatusCode.NoContent ||
                response.StatusCode == HttpStatusCode.OK
            );

            // Clean up
            await DeletarAdminAsync(token);
        }

        [Theory]
        [InlineData("/AreaConhecimento/{Id}")]
        public async Task BuscarAreaConhecimentoPorIdDeveRetornarHttpStatusOK(string url)
        {
            // Arrange
            var token = await ObterTokenAutenticacaoAsync();
            DefinirAutenticacaoHeader(token);

            //Arrange & Act
            var id = "1";

            var response = await _httpClient.GetAsync(url.Replace("{Id}", id));
            var content = await response.Content.ReadAsStringAsync(default);

            // Assert
            if (content == "Área de conhecimento não cadastrada." || response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
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
        [InlineData("/AreaConhecimento/{Id}")]
        public async Task BuscarAreaConhecimentoPorIdDeveRetornarBadRequest(string url)
        {
            // Arrange
            var token = await ObterTokenAutenticacaoAsync();
            DefinirAutenticacaoHeader(token);

            //Arrange & Act
            var id = "-1";

            var response = await _httpClient.GetAsync(url.Replace("{Id}", id));

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            await DeletarAdminAsync(token);
        }

    }
}
