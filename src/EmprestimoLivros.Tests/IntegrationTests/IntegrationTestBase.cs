using EmprestimoLivros.Application.DTOs.Autenticar;
using EmprestimoLivros.Application.DTOs.Usuario.Request;
using EmprestimosLivros.API;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace EmprestimoLivros.Tests.IntegrationTests
{
    public class IntegrationTestBase : IClassFixture<WebApplicationFactory<Startup>>
    {
        protected readonly HttpClient _httpClient;
        protected readonly WebApplicationFactory<Startup> _factory;

        public IntegrationTestBase(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _httpClient = factory.CreateClient();
        }

        protected async Task CriarUsuarioAsync(CadastrarUsuarioRequestDTO usuarioDTO)
        {
            await _httpClient.PostAsJsonAsync("/Usuario", usuarioDTO);
        }

        protected async Task<string> ObterTokenAutenticacaoAsync(string login, string password)
        {
            var usuarioDTO = new CadastrarUsuarioRequestDTO
            {
                Id = 1,
                Nome = "Admin",
                Matricula = "000001",
                DataNascimento = new DateTime(1990, 1, 1),
                TipoUsuario = "Admin",
                Login = login,
                Password = password,
                Role = "Admin"
            };

            await CriarUsuarioAsync(usuarioDTO);

            var loginDto = new UsuarioLoginDTO { Login = login, Password = password };
            var response = await _httpClient.PostAsJsonAsync("/Autenticar", loginDto);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<TokenDTO>();

            return result?.Token;
        }

        protected void DefinirAutenticacaoHeader(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        protected async Task DeletarUsuarioAsync(int id)
        {
            await _httpClient.DeleteAsync($"/Usuario/{id}");
        }
    }
}