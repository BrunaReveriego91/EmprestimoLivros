using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using Blazored.LocalStorage;

namespace EmprestimosLivroFront.Services
{
    public class AuthProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public AuthProvider(ILocalStorageService localStorage, IHttpClientFactory httpFactory)
        {
            _localStorage = localStorage;
            _httpClient = httpFactory.CreateClient("TechChallenge");
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var usuario = new ClaimsPrincipal();
            var token = await _localStorage.GetItemAsync<string>("authToken");
            if (!string.IsNullOrEmpty(token) && ValidateToken(token))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var claims = tokenHandler.ReadJwtToken(token).Claims;
                var identity = new ClaimsIdentity(claims, "jwt");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);                
                usuario = new ClaimsPrincipal(identity);
            }


            return new AuthenticationState(usuario);
        }

        public async Task SetAuthenticationStateAsync(string token)
        {
            await _localStorage.SetItemAsync("authToken", token);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task ClearAuthenticationStateAsync()
        {
            await _localStorage.RemoveItemAsync("authToken");
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        private bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("VMYxQOHB4QwvCi8F0MGyUZJVSfKyoAqxKmJCudYihTzP0MG50sBv9CjLJHQLGk70KUM7rPQ7iuzBO6wcvD7eAx");
            var issuer = "FiapTechChallenge";
            var audience = "audiance";
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = false,
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
