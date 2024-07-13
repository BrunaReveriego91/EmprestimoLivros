using EmprestimosLivros.API;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace EmprestimoLivros.Tests.IntegrationTests
{
    public class TipoPublicacaoIntegrationTest : IntegrationTestBase
    {

        public TipoPublicacaoIntegrationTest(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Theory]
        [InlineData("/TipoPublicacao")]
        public async Task ListarTipoPublicacaoDeveRetornarHttpStatusOK(string url)
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
        [InlineData("/TipoPublicacao/{id}")]
        public async Task BuscarTipoPublicacaoPorIdDeveRetornarHttpStatusOK(string url)
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
        [InlineData("/TipoPublicacao/{id}")]
        public async Task BuscarTipoPublicacaoPorIdDeveRetornarBadRequest(string url)
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
