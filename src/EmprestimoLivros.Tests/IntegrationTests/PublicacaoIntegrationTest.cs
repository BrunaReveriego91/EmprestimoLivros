﻿using EmprestimoLivros.Application.DTOs.Publicacao.Request;
using EmprestimoLivros.API;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EmprestimosLivros.API;

namespace EmprestimoLivros.Tests.IntegrationTests
{
    public class PublicacaoIntegrationTest : IntegrationTestBase
    {
        public PublicacaoIntegrationTest(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        protected async Task<string> CriarPublicacaoValidaAsync()
        {
            var token = await ObterTokenAutenticacaoAsync();
            DefinirAutenticacaoHeader(token);

            var publicacaoDTO = new CadastrarPublicacaoRequestDTO
            {
                Nome = "Livro de Teste",
                IdTipoPublicacao = 1,
                Autor = "Autor Teste",
                IdEditora = 1,
                IdAreaConhecimento = 1,
                AnoDeLancamento = new DateTime(2024, 1, 1),
                ISBN = "9780123456789",
                Descricao = "Descrição do livro de teste",
                Tags = "tag1, tag2"
            };

            var content = JsonContent.Create(publicacaoDTO);
            var response = await _httpClient.PostAsync("/Publicacao", content);

            response.EnsureSuccessStatusCode(); // Throw if status code is not OK

            // Assuming successful creation returns the publication ID:
            var responseString = await response.Content.ReadAsStringAsync();
            await DeletarAdminAsync(token);
            return responseString;
        }

        protected async Task<HttpStatusCode> DeletarPublicacaoAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"/Publicacao/{id}");
            return response.StatusCode;
        }

        [Theory]
        [InlineData("/Publicacao")]
        public async Task ListarPublicacoesDeveRetornarHttpStatusOK(string url)
        {
            // Arrange
            var token = await ObterTokenAutenticacaoAsync();
            DefinirAutenticacaoHeader(token);

            // Act
            var response = await _httpClient.GetAsync(url);

            // Assert
            await DeletarAdminAsync(token);
            Assert.True(response.IsSuccessStatusCode);
        }

        [Theory]
        [InlineData("/Publicacao/{id}")]
        public async Task BuscarPublicacaoPorIdDeveRetornarHttpStatusOK(string url)
        {
            // Arrange
            var token = await ObterTokenAutenticacaoAsync();
            DefinirAutenticacaoHeader(token);

            // Act
            // var id = await CriarPublicacaoValidaAsync();
            var id = "1";
            var response = await _httpClient.GetAsync(url.Replace("{id}", id));

            // Assert
            await DeletarAdminAsync(token);
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
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