using EmprestimosLivros.API;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace EmprestimoLivros.Tests.IntegrationTests
{
    public class EditoraIntegrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        readonly HttpClient _httpClient;
        public EditoraIntegrationTest(WebApplicationFactory<Startup> fixture)
        {
            _httpClient = fixture.CreateClient();
        }

        [Theory]
        [InlineData("/Editora")]
        public async Task ListarEditoras(string url)
        {
            //Arrange & Act
            var response = await _httpClient.GetAsync(url);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
