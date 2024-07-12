﻿using EmprestimosLivros.API;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace EmprestimoLivros.Tests.IntegrationTests
{
    public class EditoraIntegrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        readonly HttpClient _httpClient;
        public EditoraIntegrationTest(WebApplicationFactory<Startup> fixture)
        {
            _httpClient = fixture.CreateClient();
        }

        [Theory]
        [InlineData("/Editora")]
        public async Task ListarEditorasDeveRetornarHttpStatusOK(string url)
        {
            //Arrange & Act
            var response = await _httpClient.GetAsync(url);

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/Editora/{id}")]
        public async Task BuscarEditoraPorIdDeveRetornarHttpStatusOK(string url)
        {
            //Arrange & Act
            var id = "1";

            var response = await _httpClient.GetAsync(url.Replace("{id}", id));

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/Editora/{id}")]
        public async Task BuscarEditoraPorIdDeveRetornarBadRequest(string url)
        {
            //Arrange & Act
            var id = "-1";

            var response = await _httpClient.GetAsync(url.Replace("{id}", id));

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
