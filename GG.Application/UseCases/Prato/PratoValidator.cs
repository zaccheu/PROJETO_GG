using FluentValidation;
using GG.Communication.Requests;

namespace GG.Application.UseCases.Prato;

public class PratoValidator : AbstractValidator<RequestSalvarPratoJson>
{
    public PratoValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome do prato é obrigatório.")
            .MaximumLength(100).WithMessage("O nome do prato deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Preco)
            .GreaterThan(0M).WithMessage("O preço do prato deve ser maior que zero.");

        RuleFor(x => x.Produtos)
            .NotNull().WithMessage("A lista de produtos do prato é obrigatória.")
            .NotEmpty().WithMessage("O prato deve conter ao menos um produto.");

        RuleForEach(x => x.Produtos).ChildRules(pratoProduto =>
        {
            // cada item PratoProduto deve conter uma lista de produtos válidos
            pratoProduto.RuleFor(pp => pp.Produtos)
                .NotNull().WithMessage("A lista de produtos interna é obrigatória.")
                .NotEmpty().WithMessage("Deve haver pelo menos um produto dentro do item do prato.");

            pratoProduto.RuleForEach(pp => pp.Produtos).ChildRules(produto =>
            {
                produto.RuleFor(p => p.Quantidade)
                    .GreaterThan(0).WithMessage("A quantidade do produto deve ser maior que zero.");

                produto.RuleFor(p => p.Preco)
                    .GreaterThan(0M).WithMessage("O preço do produto deve ser maior que zero.");

                produto.RuleFor(p => p.Nome)
                    .NotEmpty().WithMessage("O nome do produto é obrigatório.")
                    .MaximumLength(100).WithMessage("O nome do produto deve ter no máximo 100 caracteres.");
            });
        });
    }
}