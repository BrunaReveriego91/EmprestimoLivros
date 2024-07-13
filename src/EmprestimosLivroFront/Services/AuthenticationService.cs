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
    public class AuthenticationService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;
        private readonly AuthProvider _authProvider;
        public AuthenticationService(ILocalStorageService localStorage, IHttpClientFactory httpFactory, AuthProvider authProvider)
        {
            _authProvider = authProvider;
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
                await _localStorage.SetItemAsync("authToken", token?.Token!);
                await _authProvider.SetAuthenticationStateAsync(token.Token!);
                return new AuthResponse { Sucesso = true };
            }
            return new AuthResponse { Sucesso = false, Error = ["Usuário ou senha inválidos"] };
        }

       

    }
}
