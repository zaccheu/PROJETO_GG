using FluentValidation;
using GG.Communication.Requests;

namespace GG.Application.UseCases.Pedidos;

internal class PedidoValidator : AbstractValidator<RequestSalvarPedidoJson>
{
    public PedidoValidator()
    {
        RuleFor(x => x.Data)
            .NotEmpty()
            .WithMessage("A data do pedido é obrigatória.");

        RuleFor(x => x.Itens)
            .NotEmpty()
            .WithMessage("O pedido deve conter pelo menos um item.");

        RuleForEach(x => x.Itens).ChildRules(item =>
        {
            item.RuleFor(x => x.IdPrato)
                .GreaterThan(0)
                .WithMessage("O ID do prato deve ser maior que zero.");

            item.RuleFor(x => x.Quantidade)
                .GreaterThan(0)
                .WithMessage("A quantidade deve ser maior que zero.");
        });
    }
}