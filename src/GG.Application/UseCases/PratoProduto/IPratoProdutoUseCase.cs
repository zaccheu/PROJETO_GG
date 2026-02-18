using GG.Communication.Requests;
using GG.Communication.Responses.PratoProduto;

namespace GG.Application.UseCases.PratoProduto;

public interface IPratoProdutoUseCase
{
    Task<ResponsePratoProdutoRegistradoJson> Salvar(RequestSalvarPratoProdutoJson pedido);
    Task<List<ResponsePratoProdutoJson>> Listar();
    Task<bool> Deletar(int idPedido);
}
