using EmprestimosLivros.API;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace EmprestimoLivros.Tests.IntegrationTests
{
    public class PublicacaoIntegrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        readonly HttpClient _httpClient;

        public PublicacaoIntegrationTest(WebApplicationFactory<Startup> fixture)
        {
            _httpClient = fixture.CreateClient();
        }

        [Theory]
        [InlineData("/Publicacao")]
        public async Task ListarPublicacoesDeveRetornarHttpStatusOK(string url)
        {
            //Arrange & Act                     
            var response = await _httpClient.GetAsync(url);

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/Publicacao/{id}")]
        public async Task BuscarPublicacaoPorIdDeveRetornarHttpStatusOK(string url)
        {
            //Arrange & Act
            var id = "1";

            var response = await _httpClient.GetAsync(url.Replace("{id}", id));

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/Publicacao/{id}")]
        public async Task BuscarPublicacaoPorIdDeveRetornarBadRequest(string url)
        {
            //Arrange & Act
            var id = "-1";

            var response = await _httpClient.GetAsync(url.Replace("{id}", id));

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

    }
}
