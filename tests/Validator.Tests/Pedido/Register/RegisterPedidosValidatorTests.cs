using FluentAssertions;
using GG.Application.UseCases.Produtos;
using GG.Comum.Tests.Produto;

namespace Validator.Tests.Pedido.Register;

public class RegisterPedidosValidatorTests
{
    //    [Fact]
    //    public void Success()
    //    {
    //        var validator = new PedidoValidator();
    //        var request = RequestSalvarPedidoJsonBuilder.Build();

    //        var result = validator.Validate(request);

    //        result.IsValid.Should().BeTrue();
    //    }

    //    [Fact]
    //    public void Error_Produtos_Null()
    //    {
    //        var validator = new PedidoValidator();
    //        var request = RequestSalvarPedidoJsonBuilder.Build();
    //        request.Produtos = null;

    //        var result = validator.Validate(request);

    //        result.IsValid.Should().BeFalse();
    //        result.Errors.Should().Contain(e => e.PropertyName == "Produtos");
    //    }

    //    [Fact]
    //    public void Error_Produtos_Empty()
    //    {
    //        var validator = new PedidoValidator();
    //        var request = RequestSalvarPedidoJsonBuilder.Build();
    //        request.Produtos = new List<RequestSalvarProdutoJson>();

    //        var result = validator.Validate(request);

    //        result.IsValid.Should().BeFalse();
    //        result.Errors.Should().Contain(e => e.PropertyName == "Produtos");
    //    }

    //    [Theory]
    //    [InlineData("")]
    //    [InlineData("      ")]
    //    [InlineData(null)]
    //    public void Error_Nome_Empty(string nome)
    //    {
    //        var validator = new PedidoValidator();
    //        var request = RequestSalvarPedidoJsonBuilder.Build();
    //        //request. = nome;

    //        var result = validator.Validate(request);

    //        result.IsValid.Should().BeFalse();
    //        result.Errors.Should().Contain(e => e.PropertyName == "Nome");
    //    }

    //[Theory]
    //[InlineData(0)]
    //[InlineData(-1)]
    //[InlineData(-100)]
    //public void Error_Preco_Invalid(decimal preco)
    //{
    //    var validator = new PedidoValidator();
    //    RequestSalvarPedidoJson request = RequestSalvarPedidoJsonBuilder.Build();
    //    request.ValorTotal = preco;

    //    var result = validator.Validate(request);

    //    result.IsValid.Should().BeFalse();
    //    result.Errors.Should().Contain(e => e.PropertyName == "Preco");
    //}

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