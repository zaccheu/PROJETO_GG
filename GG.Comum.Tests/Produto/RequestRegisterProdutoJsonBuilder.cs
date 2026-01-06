using Bogus;
using GG.Communication.Requests;

namespace GG.Comum.Tests.Produto;

public class RequestSalvarProdutoJsonBuilder
{
    public static RequestSalvarProdutoJson Build()
    {
        return new Faker<RequestSalvarProdutoJson>()
            .RuleFor(r => r.Id, f => f.Random.Int(1, 1000))
            .RuleFor(r => r.Nome, f => f.Commerce.ProductName())
            .RuleFor(r => r.Preco, f => f.Random.Decimal(1, 1000))
            .RuleFor(r => r.PrecoDescontado, f => f.Random.Decimal(0, 999))
            .RuleFor(r => r.Quantidade, f => f.Random.Int(1, 100))
            .RuleFor(r => r.Descricao, f => f.Commerce.ProductDescription())
            .RuleFor(r => r.Categoria, f => f.Commerce.Categories(1)[0]);
    }
}
