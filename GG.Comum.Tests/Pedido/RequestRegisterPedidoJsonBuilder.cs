using Bogus;
using GG.Communication.Requests;

namespace GG.Comum.Tests.Produto;

public class RequestSalvarPedidoJsonBuilder
{
    public static RequestSalvarPedidoJson Build()
    {
        return new Faker<RequestSalvarPedidoJson>()
            .RuleFor(r => r.Id, f => f.Random.Int(1, 1000))
            .RuleFor(r => r.Produtos, f => Enumerable
                .Range(1, f.Random.Int(1, 5))
                .Select(_ => RequestSalvarProdutoJsonBuilder.Build())
                .ToList());
    }
}
