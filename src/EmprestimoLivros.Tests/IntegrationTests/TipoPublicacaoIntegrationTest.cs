using EmprestimosLivros.API;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace EmprestimoLivros.Tests.IntegrationTests
{
    public class TipoPublicacaoIntegrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        readonly HttpClient _httpClient;

        public TipoPublicacaoIntegrationTest(WebApplicationFactory<Startup> fixture)
        {
            _httpClient = fixture.CreateClient();
        }

        [Theory]
        [InlineData("/TipoPublicacao")]
        public async Task ListarTipoPublicacaoDeveRetornarHttpStatusOK(string url)
        {
            //Arrange & Act
            var response = await _httpClient.GetAsync(url);

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/TipoPublicacao/{id}")]
        public async Task BuscarTipoPublicacaoPorIdDeveRetornarHttpStatusOK(string url)
        {
            //Arrange & Act
            var id = "1";

            var response = await _httpClient.GetAsync(url.Replace("{id}", id));

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/TipoPublicacao/{id}")]
        public async Task BuscarTipoPublicacaoPorIdDeveRetornarBadRequest(string url)
        {
            //Arrange & Act
            var id = "-1";

            var response = await _httpClient.GetAsync(url.Replace("{id}", id));

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
