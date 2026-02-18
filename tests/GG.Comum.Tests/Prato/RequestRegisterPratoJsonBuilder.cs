using Bogus;
using GG.Communication.Requests;
using GG.Comum.Tests.Produto;

namespace GG.Comum.Tests.Prato;

public class RequestSalvarPratoJsonBuilder
{
    //PRECISA MELHORAR AQUI
    public static RequestSalvarPratoJson Build()
    {
        return new Faker<RequestSalvarPratoJson>()
             .RuleFor(r => r.Nome, f => f.Commerce.ProductName())
             .RuleFor(r => r.Preco, f => f.Random.Decimal(1, 1000))
             .RuleFor(r => r.Produtos, (f, r) =>
             {
                 var itensCount = f.Random.Int(1, 5);

                 return Enumerable.Range(1, itensCount)
                     .Select(_ =>
                     {
                         var produtosCount = f.Random.Int(1, 3);
                         var produtos = Enumerable.Range(1, produtosCount)
                             .Select(__ => RequestSalvarProdutoJsonBuilder.Build())
                             .ToList();

                         return new RequestSalvarPratoProdutoJson
                         {
                             Id = f.Random.Int(1, 1000),
                             Produtos = produtos,
                             IdPedido = f.Random.Int(1, 1000),
                             DataPedido = f.Date.Recent(),
                             ValorTotal = produtos.Sum(p => p.Preco * p.Quantidade)
                         };
                     })
                     .ToList();
             })
             .Generate();
    }
}
