using FluentValidation;
using GG.Communication.Requests;

namespace GG.Application.UseCases.Produtos;

public class ProdutoValidator : AbstractValidator<RequestSalvarProdutoJson>
{
    public ProdutoValidator()
    {
        RuleFor(produto => produto.Nome)
            .NotEmpty().WithMessage("O nome do produto é obrigatório.")
            .MaximumLength(100).WithMessage("O nome do produto deve ter no máximo 100 caracteres.");

        RuleFor(produto => produto.Preco)
            .GreaterThan(0).WithMessage("O preço do produto deve ser maior que zero.");

        RuleFor(produto => produto.Descricao)
            .MaximumLength(500).WithMessage("A descrição do produto deve ter no máximo 500 caracteres.");
    }
}