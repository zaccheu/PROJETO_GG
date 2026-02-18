using GG.Communication.Requests;
using GG.Communication.Responses.PedidoPrato;

namespace GG.Application.UseCases.PedidoPrato;

public interface IPedidoPratoUseCase
{
    Task<ResponsePedidoPratoRegistradoJson> Salvar(RequestSalvarPedidoPratoJson pedido);
    Task<List<ResponsePedidoPratoJson>> Listar();
    Task<bool> Deletar(int idPedido);
}
