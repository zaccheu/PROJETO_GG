using Bogus;
using GG.Communication.Requests;
using GG.Comum.Tests.Produto;

namespace GG.Comum.Tests.PedidoPrato;

public class RequestSalvarPedidoPratoJsonBuilder
{
    public static RequestSalvarPedidoPratoJson Build()
    {
        return new Faker<RequestSalvarPedidoPratoJson>()
            .RuleFor(r => r.Id, f => f.Random.Int(1, 1000))
            .RuleFor(r => r.Produtos, f => Enumerable
                .Range(1, f.Random.Int(1, 5))
                .Select(_ => RequestSalvarProdutoJsonBuilder.Build())
                .ToList());
    }
}