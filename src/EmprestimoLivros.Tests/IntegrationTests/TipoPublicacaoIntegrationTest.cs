﻿using EmprestimosLivros.API;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace EmprestimoLivros.Tests.IntegrationTests
{
    public class TipoPublicacaoIntegrationTest : IntegrationTestBase
    {

        public TipoPublicacaoIntegrationTest(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Theory]
        [InlineData("/TipoPublicacao")]
        public async Task ListarTipoPublicacaoDeveRetornarHttpStatusOK(string url)
        {
            // Arrange
            var token = await ObterTokenAutenticacaoAsync();
            DefinirAutenticacaoHeader(token);

            //Arrange & Act
            var response = await _httpClient.GetAsync(url);

            //Assert
            await DeletarAdminAsync(token);
            Assert.True(response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/TipoPublicacao/{id}")]
        public async Task BuscarTipoPublicacaoPorIdDeveRetornarHttpStatusOK(string url)
        {
            // Arrange
            var token = await ObterTokenAutenticacaoAsync();
            DefinirAutenticacaoHeader(token);

            //Arrange & Act
            var id = "1";

            var response = await _httpClient.GetAsync(url.Replace("{id}", id));
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            await DeletarAdminAsync(token);
            if (content == $"Tipo de publicação com o ID {id} não encontrada." || response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK);
            }
        }
    }
}
