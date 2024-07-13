using EmprestimosLivros.API;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace EmprestimoLivros.Tests.IntegrationTests
{
    public class UsuarioIntegrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        readonly HttpClient _httpClient;

        public UsuarioIntegrationTest(WebApplicationFactory<Startup> fixture)
        {
            _httpClient = fixture.CreateClient();
        }


        [Theory]
        [InlineData("/Usuario")]
        public async Task ListarUsuariosDeveRetornarHttpStatusOK(string url)
        {
            //Arrange & Act                     
            var response = await _httpClient.GetAsync(url);

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/Usuario/{id}")]
        public async Task BuscarUsuarioPorIdDeveRetornarHttpStatusOK(string url)
        {
            //Arrange & Act
            var id = "1";

            var response = await _httpClient.GetAsync(url.Replace("{id}", id));

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/Usuario/{id}")]
        public async Task BuscarUsuarioPorIdDeveRetornarBadRequest(string url)
        {
            //Arrange & Act
            var id = "-1";

            var response = await _httpClient.GetAsync(url.Replace("{id}", id));

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

    }
}
