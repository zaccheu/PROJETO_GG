using FluentValidation;
using GG.Dto;

namespace GG.Application.UseCases.Categorias;
public class CategoriaValidator : AbstractValidator<RequestSalvarCategoriaJson>
{
    public CategoriaValidator()
    {
        RuleFor(produto => produto.Nome)
            .NotEmpty().WithMessage("O nome do produto é obrigatório.")
            .MaximumLength(100).WithMessage("O nome do produto deve ter no máximo 100 caracteres.");

        RuleFor(produto => produto.Descricao)
            .MaximumLength(500).WithMessage("A descrição do produto deve ter no máximo 500 caracteres.");
    }
}