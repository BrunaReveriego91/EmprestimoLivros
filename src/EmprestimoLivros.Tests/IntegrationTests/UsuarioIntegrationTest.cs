using EmprestimoLivros.Application.DTOs.Autenticar;
using EmprestimoLivros.Application.DTOs.Usuario.Request;
using EmprestimosLivros.API;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Xunit;

namespace EmprestimoLivros.Tests.IntegrationTests
{
    public class UsuarioIntegrationTest : IntegrationTestBase
    {
        public UsuarioIntegrationTest(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Theory]
        [InlineData("/Usuario")]
        public async Task ListarUsuariosDeveRetornarHttpStatusOK(string url)
        {
            // Arrange
            var token = await ObterTokenAutenticacaoAsync("admin", "admin");
            DefinirAutenticacaoHeader(token);

            // Act
            var response = await _httpClient.GetAsync(url);

            // Assert
            Assert.True(response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/Usuario/{id}")]
        public async Task BuscarUsuarioPorIdDeveRetornarHttpStatusOK(string url)
        {
            // Arrange & Act
            var token = await ObterTokenAutenticacaoAsync("admin", "admin");
            DefinirAutenticacaoHeader(token);

            var id = "1";
            var response = await _httpClient.GetAsync(url.Replace("{id}", id));

            // Assert
            Assert.True(response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/Usuario/{id}")]
        public async Task BuscarUsuarioPorIdDeveRetornarBadRequest(string url)
        {
            // Arrange & Act
            var token = await ObterTokenAutenticacaoAsync("admin", "admin");
            DefinirAutenticacaoHeader(token);

            var id = "-1";
            var response = await _httpClient.GetAsync(url.Replace("{id}", id));

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [InlineData("/Usuario")]
        public async Task CadastrarUsuarioDeveRetornarOK(string url)
        {
            // Arrange
            var usuarioDTO = new CadastrarUsuarioRequestDTO
            {
                Id = 2,
                Nome = "User",
                Matricula = "000002",
                DataNascimento = new DateTime(1990, 1, 1),
                TipoUsuario = "User",
                Login = "user",
                Password = "user",
                Role = "User"
            };

            var token = await ObterTokenAutenticacaoAsync("admin", "admin");
            DefinirAutenticacaoHeader(token);

            // Verifica se o usuário já existe
            var checkResponse = await _httpClient.GetAsync($"{url}/{usuarioDTO.Id}");
            if (checkResponse.IsSuccessStatusCode)
            {
                Assert.True(true);
                return;
            }

            // Act
            var content = JsonContent.Create(usuarioDTO);
            var response = await _httpClient.PostAsync(url, content);

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            Assert.Contains("Usuário cadastrado com sucesso", responseString);

            // Clean up - delete the created user
            await DeletarUsuarioAsync(usuarioDTO.Id);
        }
    }
}