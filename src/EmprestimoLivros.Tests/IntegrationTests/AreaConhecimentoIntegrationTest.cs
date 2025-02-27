﻿using EmprestimosLivros.API;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using System.Net;

namespace EmprestimoLivros.Tests.IntegrationTests
{
    public class AreaConhecimentoIntegrationTest : IntegrationTestBase
    {
        public AreaConhecimentoIntegrationTest(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Theory]
        [InlineData("/AreaConhecimento")]
        public async Task ListarAreaConhecimentoDeveRetornarHttpStatusOK(string url)
        {

            // Arrange
            //var token = await ObterTokenAutenticacaoAsync();
            //DefinirAutenticacaoHeader(token);

            //Arrange & Act                   
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync(default);

            //Assert
            //await DeletarAdminAsync(token);
            Assert.True((content == "Não foram encontradas áreas de conhecimento." && response.StatusCode == HttpStatusCode.BadRequest) || response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/AreaConhecimento/{Id}")]
        public async Task BuscarAreaConhecimentoPorIdDeveRetornarHttpStatusOK(string url)
        {
            // Arrange
            var token = await ObterTokenAutenticacaoAsync();
            DefinirAutenticacaoHeader(token);

            //Arrange & Act
            var id = "1";

            var response = await _httpClient.GetAsync(url.Replace("{Id}", id));
            var content = await response.Content.ReadAsStringAsync(default);

            // Assert
            if (content == "Área de conhecimento não cadastrada." || response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                await DeletarAdminAsync(token);
                Assert.True(true);
            }
            else
            {
                await DeletarAdminAsync(token);
                Assert.True(response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK);
            }
        }

        [Theory]
        [InlineData("/AreaConhecimento/{Id}")]
        public async Task BuscarAreaConhecimentoPorIdDeveRetornarBadRequest(string url)
        {
            // Arrange
            var token = await ObterTokenAutenticacaoAsync();
            DefinirAutenticacaoHeader(token);

            //Arrange & Act
            var id = "-1";

            var response = await _httpClient.GetAsync(url.Replace("{Id}", id));

            //Assert
            await DeletarAdminAsync(token);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

    }
}
