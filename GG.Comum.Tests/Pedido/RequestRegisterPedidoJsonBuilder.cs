using Bogus;
using GG.Communication.Requests;

namespace GG.Comum.Tests.Produto;

public class RequestSalvarPedidoJsonBuilder
{
    public static RequestSalvarPedidoJson Build()
    {
        return new Faker<RequestSalvarPedidoJson>()
            .RuleFor(r => r.Id, f => f.Random.Int(1, 1000))
            .RuleFor(r => r.IdCliente, f => f.Random.Int(1, 1000))
            .RuleFor(r => r.Data, f => f.Date.Recent())
            .RuleFor(r => r.Itens, (f, r) => Enumerable
                .Range(1, f.Random.Int(1, 5))
                .Select(_ => new RequestItemPedidoJson
                {
                    IdPrato = f.Random.Int(1, 1000),
                    Quantidade = f.Random.Int(1, 10)
                })
                .ToList())
            .Generate();
    }
}
