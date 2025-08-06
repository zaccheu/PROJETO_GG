using FluentAssertions;
using GG.Application.UseCases.Produtos;
using GG.Comum.Tests.Produto;

namespace Validator.Tests.Produtos.Register;

public class RegisterProdutosValidatorTests
{
    [Fact]
    public void Success()
    {
        var validator = new ProdutoValidator();
        var request = RequestSalvarProdutoJsonBuilder.Build();

        var result = validator.Validate(request);

        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("      ")]
    [InlineData(null)]
    public void Error_Nome_Empty(string nome)
    {
        var validator = new ProdutoValidator();
        var request = RequestSalvarProdutoJsonBuilder.Build();
        request.Nome = nome;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Nome");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void Error_Preco_Invalid(decimal preco)
    {
        var validator = new ProdutoValidator();
        var request = RequestSalvarProdutoJsonBuilder.Build();
        request.Preco = preco;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Preco");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void Error_Quantidade_Invalid(int quantidade)
    {
        var validator = new ProdutoValidator();
        var request = RequestSalvarProdutoJsonBuilder.Build();
        request.Quantidade = quantidade;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Quantidade");
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Error_Categoria_Empty(string categoria)
    {
        var validator = new ProdutoValidator();
        var request = RequestSalvarProdutoJsonBuilder.Build();
        request.Categoria = categoria;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Categoria");
    }

    [Fact]
    public void Error_Nome_TooLong()
    {
        var validator = new ProdutoValidator();
        var request = RequestSalvarProdutoJsonBuilder.Build();
        request.Nome = new string('A', 101);

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Nome");
    }

    [Fact]
    public void Error_Descricao_TooLong()
    {
        var validator = new ProdutoValidator();
        var request = RequestSalvarProdutoJsonBuilder.Build();
        request.Descricao = new string('A', 501);

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Descricao");
    }
}