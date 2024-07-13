using EmprestimoLivros.Application.DTOs.Autenticar;
using EmprestimoLivros.Application.DTOs.Usuario.Request;
using EmprestimosLivros.API;
using Microsoft.AspNetCore.Mvc.Testing;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;

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

        public string GetUserIdFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            // Log para verificar os claims
            foreach (var jwtClaim in jwtToken.Claims)
            {
                Console.WriteLine($"Claim Type: {jwtClaim.Type}, Claim Value: {jwtClaim.Value}");
            }

            var claim = jwtToken.Claims.FirstOrDefault(c => c.Type == "nameid");
            return claim?.Value;
        }

        protected async Task CriarUsuarioAsync(CadastrarUsuarioRequestDTO usuarioDTO)
        {
            await _httpClient.PostAsJsonAsync("/Usuario", usuarioDTO);
        }

        protected async Task<string> ObterTokenAutenticacaoAsync(
            string login = "adminTester",
            string password = "adminTester"
        )
        {
            var usuarioDTO = new CadastrarUsuarioRequestDTO
            {
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

        protected async Task DeletarUsuarioAsync(int? id = null, string token = null)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("Token de autorização é obrigatório");
            }
            DefinirAutenticacaoHeader(token);

            if (id.HasValue)
            {
                var response = await _httpClient.DeleteAsync($"/Usuario/{id.Value}");
                if (!response.IsSuccessStatusCode)
                {
                    var deleteError = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Erro ao deletar usuário {id}: {deleteError}");
                }
            }
            else
            {
                throw new Exception("ID do usuário é obrigatório");
            }
        }
        protected async Task DeletarAdminAsync(string token = null)
        {
            // Obter o ID do usuário logado a partir do token
            var idLoggedUser = GetUserIdFromToken(token);
            if (idLoggedUser == null)
            {
                throw new Exception("ID do usuário não encontrado no token");
            }
            // Tenta excluir o usuário logado (admin)
            if (int.TryParse(idLoggedUser, out var id))
            {
                await DeletarUsuarioAsync(id, token);
            }
            else
            {
                throw new Exception($"ID do usuário logado ({idLoggedUser}) não é um número válido");
            }
        }
    }
}
