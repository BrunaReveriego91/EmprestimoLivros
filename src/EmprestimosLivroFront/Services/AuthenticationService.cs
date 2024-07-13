using Blazored.LocalStorage;
using EmprestimoLivros.Application.DTOs.Autenticar;
using EmprestimosLivroFront.Response;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace EmprestimosLivroFront.Services
{
    public class AuthenticationService : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;
        public AuthenticationService(ILocalStorageService localStorage, IHttpClientFactory httpFactory)
        {
            _localStorage = localStorage;
            _httpClient = httpFactory.CreateClient("TechChallenge");
        }

        public async Task<AuthResponse> AutenticarAsync(string usuario, string password)
        {
            var response = await _httpClient.PostAsJsonAsync("/Autenticar", new
            {
                Login = usuario,
                Password = password,
            });

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadFromJsonAsync<TokenResponse>();
                await _localStorage.SetItemAsync("authToken", token.Token);
                NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
                return new AuthResponse { Sucesso = true };
            }
            return new AuthResponse { Sucesso = false, Error = ["Usuário ou senha inválidos"] };
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var usuario = new ClaimsPrincipal();
            var token = await _localStorage.GetItemAsync<string>("authToken");
            if (!string.IsNullOrEmpty(token) && ValidateToken(token))
            {
                var identity = new ClaimsIdentity(ParseClaimsFromJwt(token));
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                usuario = new ClaimsPrincipal(identity);
            }
            return new AuthenticationState(usuario);
        }

        private bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("VMYxQOHB4QwvCi8F0MGyUZJVSfKyoAqxKmJCudYihTzP0MG50sBv9CjLJHQLGk70KUM7rPQ7iuzBO6wcvD7eAx");
            var issuer = "FiapTechChallenge";
            var audience = "audiance";
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };

            try
            {
                tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);
            return token.Claims;
        }

    }
}
