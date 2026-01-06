using FluentValidation;
using GG.Communication.Requests;

namespace GG.Application.UseCases.PedidoPrato;

public class PedidoPratoValidator : AbstractValidator<RequestSalvarPedidoPratoJson>
{
    public PedidoPratoValidator()
    {

    }
}