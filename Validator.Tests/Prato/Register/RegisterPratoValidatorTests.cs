using FluentAssertions;
using GG.Application.UseCases.Prato;
using GG.Comum.Tests.Prato;

namespace Validator.Tests.Prato.Register;

public class RegisterPratoValidatorTests
{
    [Fact]
    public void Success()
    {
        var validator = new PratoValidator();
        var request = RequestSalvarPratoJsonBuilder.Build();

        var result = validator.Validate(request);

        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("      ")]
    [InlineData(null)]
    public void Error_Nome_Empty(string nome)
    {
        var validator = new PratoValidator();
        var request = RequestSalvarPratoJsonBuilder.Build();
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
        var validator = new PratoValidator();
        var request = RequestSalvarPratoJsonBuilder.Build();
        request.ValorTotal = preco;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Preco");
    }

    [Fact]
    public void Error_Descricao_TooLong()
    {
        var validator = new PratoValidator();
        var request = RequestSalvarPratoJsonBuilder.Build();

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Descricao");
    }
}