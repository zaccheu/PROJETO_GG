using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using GG.Communication.Requests;
using GG.Communication.Responses.Prato;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace GG.Integration.Tests;

public class PratoControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _jsonOptions;

    public PratoControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    [Fact]
    public async Task CriarPrato_DeveRetornarCreated_QuandoDadosValidos()
    {
        // Arrange
        var novoPrato = new RequestSalvarPratoJson
        {
            Nome = "Cerveja Teste",
            Preco = 15.00M
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/pratos", novoPrato);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        
        var pratoRegistrado = await response.Content.ReadFromJsonAsync<ResponsePratoRegistradoJson>(_jsonOptions);
        Assert.NotNull(pratoRegistrado);
        Assert.True(pratoRegistrado.IdPrato > 0);
        Assert.Equal(novoPrato.Nome, pratoRegistrado.Nome);
        Assert.Equal(novoPrato.Preco, pratoRegistrado.Preco);
    }

    [Fact]
    public async Task CriarPrato_DeveRetornarBadRequest_QuandoNomeVazio()
    {
        // Arrange
        var pratoInvalido = new RequestSalvarPratoJson
        {
            Nome = "",
            Preco = 10.00M
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/pratos", pratoInvalido);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CriarPrato_DeveRetornarBadRequest_QuandoPrecoZero()
    {
        // Arrange
        var pratoInvalido = new RequestSalvarPratoJson
        {
            Nome = "Prato Teste",
            Preco = 0
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/pratos", pratoInvalido);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task ListarPratos_DeveRetornarOk_ComListaDePratos()
    {
        // Arrange - Criar um prato primeiro
        var novoPrato = new RequestSalvarPratoJson
        {
            Nome = "Prato para Listar",
            Preco = 20.00M
        };
        await _client.PostAsJsonAsync("/api/pratos", novoPrato);

        // Act
        var response = await _client.GetAsync("/api/pratos");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        
        var pratos = await response.Content.ReadFromJsonAsync<List<ResponsePratoJson>>(_jsonOptions);
        Assert.NotNull(pratos);
        Assert.NotEmpty(pratos);
    }

    [Fact]
    public async Task ObterPratoPorId_DeveRetornarOk_QuandoPratoExiste()
    {
        // Arrange - Criar um prato
        var novoPrato = new RequestSalvarPratoJson
        {
            Nome = "Prato para Buscar",
            Preco = 25.00M
        };
        var createResponse = await _client.PostAsJsonAsync("/api/pratos", novoPrato);
        var pratoRegistrado = await createResponse.Content.ReadFromJsonAsync<ResponsePratoRegistradoJson>(_jsonOptions);

        // Act
        var response = await _client.GetAsync($"/api/pratos/{pratoRegistrado!.IdPrato}");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        
        var prato = await response.Content.ReadFromJsonAsync<ResponsePratoJson>(_jsonOptions);
        Assert.NotNull(prato);
        Assert.Equal(pratoRegistrado.IdPrato, prato.IdPrato);
        Assert.Equal(novoPrato.Nome, prato.Nome);
    }

    [Fact]
    public async Task ObterPratoPorId_DeveRetornarNotFound_QuandoPratoNaoExiste()
    {
        // Act
        var response = await _client.GetAsync("/api/pratos/99999");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task AtualizarPrato_DeveRetornarOk_QuandoDadosValidos()
    {
        // Arrange - Criar um prato
        var novoPrato = new RequestSalvarPratoJson
        {
            Nome = "Prato para Atualizar",
            Preco = 30.00M
        };
        var createResponse = await _client.PostAsJsonAsync("/api/pratos", novoPrato);
        var pratoRegistrado = await createResponse.Content.ReadFromJsonAsync<ResponsePratoRegistradoJson>(_jsonOptions);

        var pratoAtualizado = new RequestSalvarPratoJson
        {
            Nome = "Prato Atualizado",
            Preco = 35.00M
        };

        // Act
        var response = await _client.PutAsJsonAsync($"/api/pratos/{pratoRegistrado!.IdPrato}", pratoAtualizado);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        
        var prato = await response.Content.ReadFromJsonAsync<ResponsePratoRegistradoJson>(_jsonOptions);
        Assert.NotNull(prato);
        Assert.Equal(pratoAtualizado.Nome, prato.Nome);
        Assert.Equal(pratoAtualizado.Preco, prato.Preco);
    }

    [Fact]
    public async Task DeletarPrato_DeveRetornarNoContent_QuandoPratoExiste()
    {
        // Arrange - Criar um prato
        var novoPrato = new RequestSalvarPratoJson
        {
            Nome = "Prato para Deletar",
            Preco = 40.00M
        };
        var createResponse = await _client.PostAsJsonAsync("/api/pratos", novoPrato);
        var pratoRegistrado = await createResponse.Content.ReadFromJsonAsync<ResponsePratoRegistradoJson>(_jsonOptions);

        // Act
        var response = await _client.DeleteAsync($"/api/pratos/{pratoRegistrado!.IdPrato}");

        // Assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        
        // Verificar se realmente foi deletado
        var getResponse = await _client.GetAsync($"/api/pratos/{pratoRegistrado.IdPrato}");
        Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
    }

    [Fact]
    public async Task DeletarPrato_DeveRetornarNotFound_QuandoPratoNaoExiste()
    {
        // Act
        var response = await _client.DeleteAsync("/api/pratos/99999");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
