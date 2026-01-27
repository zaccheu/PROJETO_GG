using FluentAssertions;
using GG.Application.UseCases.Categorias;
using GG.Comum.Tests.Produto;

namespace Validator.Tests.Categoria.Register;

public class RegisterCategoriasValidatorTests
{
    [Fact]
    public void Success()
    {
        var validator = new CategoriaValidator();
        var request = RequestSalvarCategoriaJsonBuilder.Build();

        var result = validator.Validate(request);

        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("      ")]
    [InlineData(null)]
    public void Error_Nome_Empty(string nome)
    {
        var validator = new CategoriaValidator();
        var request = RequestSalvarCategoriaJsonBuilder.Build();
        request.Nome = nome;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Nome");
    }

    [Fact]
    public void Error_Nome_TooLong()
    {
        var validator = new CategoriaValidator();
        var request = RequestSalvarCategoriaJsonBuilder.Build();
        request.Nome = new string('A', 101);

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Nome");
    }

    [Fact]
    public void Error_Descricao_TooLong()
    {
        var validator = new CategoriaValidator();
        var request = RequestSalvarCategoriaJsonBuilder.Build();
        request.Descricao = new string('A', 501);

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Descricao");
    }
}