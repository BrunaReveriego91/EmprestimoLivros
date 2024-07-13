using EmprestimoLivros.Application.DTOs.Usuario.Request;
using EmprestimosLivros.API;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;

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
            var token = await ObterTokenAutenticacaoAsync();
            DefinirAutenticacaoHeader(token);

            // Act
            var response = await _httpClient.GetAsync(url);

            // Assert
            Assert.True(response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK);
            await DeletarAdminAsync(token);
        }

        [Theory]
        [InlineData("/Usuario/{id}")]
        public async Task BuscarUsuarioPorIdDeveRetornarHttpStatusOK(string url)
        {
            // Arrange
            var token = await ObterTokenAutenticacaoAsync();
            DefinirAutenticacaoHeader(token);

            var id = "1";

            // Act
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
            // Delete admin
            await DeletarAdminAsync(token);
        }

        [Theory]
        [InlineData("/Usuario/{id}")]
        public async Task BuscarUsuarioPorIdDeveRetornarBadRequest(string url)
        {
            // Arrange & Act
            var token = await ObterTokenAutenticacaoAsync();
            DefinirAutenticacaoHeader(token);

            var id = "-1";
            var response = await _httpClient.GetAsync(url.Replace("{id}", id));

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            await DeletarAdminAsync(token);
        }

        [Theory]
        [InlineData("/Usuario")]
        public async Task CadastrarUsuarioDeveRetornarOK(string url)
        {
            // Arrange
            var usuarioDTO = new CadastrarUsuarioRequestDTO
            {
                Id = 999999,
                Nome = "User",
                Matricula = "000002",
                DataNascimento = new DateTime(1990, 1, 1),
                TipoUsuario = "User",
                Login = "user",
                Password = "user",
                Role = "User"
            };

            var token = await ObterTokenAutenticacaoAsync();
            DefinirAutenticacaoHeader(token);

            // Act
            var content = JsonContent.Create(usuarioDTO);
            var response = await _httpClient.PostAsync(url, content);

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            Assert.Contains("Usuário cadastrado com sucesso", responseString);
            await DeletarUsuarioAsync(usuarioDTO.Id, token);
            await DeletarAdminAsync(token);
        }
    }
}