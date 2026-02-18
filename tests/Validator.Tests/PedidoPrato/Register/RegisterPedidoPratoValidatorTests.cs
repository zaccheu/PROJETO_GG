using FluentAssertions;
using GG.Application.UseCases.PedidoPrato;
using GG.Comum.Tests.PedidoPrato;

namespace Validator.Tests.Produto.Register;

public class RegisterPedidoPratoValidatorTests
{
    [Fact]
    public void Success()
    {
        var validator = new PedidoPratoValidator();
        var request = RequestSalvarPedidoPratoJsonBuilder.Build();

        var result = validator.Validate(request);

        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void Error_ValorTotal_Invalid(decimal valorTotal)
    {
        var validator = new PedidoPratoValidator();
        var request = RequestSalvarPedidoPratoJsonBuilder.Build();
        request.ValorTotal = valorTotal;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Quantidade");
    }
}