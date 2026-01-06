using Bogus;
using GG.Communication.Requests;

namespace GG.Comum.Tests.Produto;

public class RequestSalvarDespesaJsonBuilder
{
    public static RequestSalvarDespesaJson Build()
    {
        return new Faker<RequestSalvarDespesaJson>()
            .RuleFor(r => r.Id, f => f.Random.Int(1, 1000))
            .RuleFor(r => r.Nome, f => f.Commerce.ProductName())
            .RuleFor(r => r.Descricao, f => f.Commerce.ProductDescription());
    }
}
