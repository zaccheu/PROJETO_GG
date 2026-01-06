using GG.Communication.Requests;
using GG.Communication.Responses.Pedido;

namespace GG.Application.UseCases.Pedidos;

public interface IPedidoUseCase
{
    Task<ResponsePedidoRegistradoJson> Salvar(RequestSalvarPedidoJson pedido);
    Task<List<ResponsePedidoJson>> Listar();
    Task<bool> Deletar(int idPedido);
}
