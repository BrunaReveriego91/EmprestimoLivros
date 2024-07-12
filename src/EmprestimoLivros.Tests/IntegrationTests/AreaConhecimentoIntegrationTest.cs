using EmprestimosLivros.API;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace EmprestimoLivros.Tests.IntegrationTests
{
    public class AreaConhecimentoIntegrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        readonly HttpClient _httpClient;

        public AreaConhecimentoIntegrationTest(WebApplicationFactory<Startup> fixture)
        {
            _httpClient = fixture.CreateClient();
        }

        [Theory]
        [InlineData("/AreaConhecimento")]
        public async Task ListarAreaConhecimentoDeveRetornarHttpStatusOK(string url)
        {
            //Arrange & Act                     
            var response = await _httpClient.GetAsync(url);

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/AreaConhecimento/{Id}")]
        public async Task BuscarAreaConhecimentoPorIdDeveRetornarHttpStatusOK(string url)
        {
            //Arrange & Act
            var id = "1";

            var response = await _httpClient.GetAsync(url.Replace("{Id}", id));

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/AreaConhecimento/{Id}")]
        public async Task BuscarAreaConhecimentoPorIdDeveRetornarBadRequest(string url)
        {
            //Arrange & Act
            var id = "-1";

            var response = await _httpClient.GetAsync(url.Replace("{Id}", id));

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

    }
}
