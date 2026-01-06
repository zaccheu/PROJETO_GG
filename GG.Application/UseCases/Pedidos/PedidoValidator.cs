using FluentValidation;
using GG.Communication.Requests;

namespace GG.Application.UseCases.Produtos;

public class PedidoValidator : AbstractValidator<RequestSalvarPedidoJson>
{
    public PedidoValidator()
    {

    }
}