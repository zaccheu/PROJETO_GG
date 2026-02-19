using FluentValidation;
using GG.Communication.Requests;

namespace GG.Application.UseCases.Despesas;

public class DespesaValidator : AbstractValidator<RequestSalvarDespesaJson>
{
    public DespesaValidator()
    {
        RuleFor(despesa => despesa.Nome)
            .NotEmpty().WithMessage("O nome do produto é obrigatório.")
            .MaximumLength(100).WithMessage("O nome do produto deve ter no máximo 100 caracteres.");

        RuleFor(despesa => despesa.Descricao)
            .MaximumLength(500).WithMessage("A descrição do produto deve ter no máximo 500 caracteres.");

        RuleFor(despesa => despesa.Valor)
            .GreaterThan(0).WithMessage("A despesa deve ter um valor!");
    }
}