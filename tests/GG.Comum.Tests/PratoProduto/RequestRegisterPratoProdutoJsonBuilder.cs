using Bogus;
using GG.Communication.Requests;
using GG.Comum.Tests.Produto;

namespace GG.Comum.Tests.PratoProduto;

public class RequestSalvarPratoProdutoJsonBuilder
{
    //PRECISA MELHORAR AQUI
    public static RequestSalvarPratoProdutoJson Build()
    {
        return new Faker<RequestSalvarPratoProdutoJson>()
            .RuleFor(r => r.Id, f => f.Random.Int(1, 1000))
            .RuleFor(r => r.ValorTotal, f => f.Random.Decimal(1, 1000))
            .RuleFor(r => r.Produtos, f => Enumerable
                .Range(1, f.Random.Int(1, 5))
                .Select(_ => RequestSalvarProdutoJsonBuilder.Build())
                .ToList());
    }
}
