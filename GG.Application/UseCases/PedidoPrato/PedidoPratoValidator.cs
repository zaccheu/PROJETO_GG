using FluentValidation;
using GG.Communication.Requests;

namespace GG.Application.UseCases.PedidoPrato;

public class PedidoPratoValidator : AbstractValidator<RequestSalvarPedidoPratoJson>
{
    public PedidoPratoValidator()
    {
        RuleFor(x => x.Produtos)
            .NotNull().WithMessage("A lista de produtos é obrigatória.")
            .NotEmpty().WithMessage("O pedido deve conter ao menos um produto.");

        RuleForEach(x => x.Produtos).ChildRules(prod =>
        {
            prod.RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage("O Id do produto é obrigatório e deve ser maior que zero.");

            prod.RuleFor(p => p.Quantidade)
                .GreaterThan(0).WithMessage("A quantidade do produto deve ser maior que zero.");

            prod.RuleFor(p => p.Preco)
                .GreaterThan(0).WithMessage("O preço do produto deve ser maior que zero.");
        });

        RuleFor(x => x.IdPedido)
            .GreaterThan(0).WithMessage("O Id do pedido é obrigatório e deve ser maior que zero.");

        RuleFor(x => x.ValorTotal)
            .GreaterThanOrEqualTo(0M)
            .When(x => x.ValorTotal.HasValue)
            .WithMessage("O valor total do pedido não pode ser negativo.");

        RuleFor(x => x.DataPedido)
            .NotEqual(default(DateTime)).WithMessage("A data do pedido é obrigatória.");
    }
}