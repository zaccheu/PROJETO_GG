using FluentAssertions;
using GG.Application.UseCases.PratoProduto;
using GG.Application.UseCases.Produtos;
using GG.Comum.Tests.PratoProduto;
using GG.Comum.Tests.Produto;

namespace Validator.Tests.Produto.Register;

public class RegisterPratoProdutoValidatorTests
{
    [Fact]
    public void Success()
    {
        var validator = new PratoProdutoValidator();
        var request = RequestSalvarPratoProdutoJsonBuilder.Build();

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
    public void Error_Quantidade_Invalid(decimal quantidade)
    {
        var validator = new PratoProdutoValidator();
        var request = RequestSalvarPratoProdutoJsonBuilder.Build();
        request.ValorTotal = quantidade;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Quantidade");
    }
}