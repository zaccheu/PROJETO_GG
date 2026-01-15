using FluentValidation;
using GG.Communication.Requests;

namespace GG.Application.UseCases.Pratos;

internal class PratoValidator : AbstractValidator<RequestSalvarPratoJson>
{
    public PratoValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("O nome do prato é obrigatório.");

        RuleFor(x => x.Preco)
            .GreaterThan(0)
            .WithMessage("O preço deve ser maior que zero.");
    }
}
