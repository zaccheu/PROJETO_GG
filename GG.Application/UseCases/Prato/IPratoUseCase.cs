using GG.Communication.Requests;
using GG.Communication.Responses.Prato;

namespace GG.Application.UseCases.Prato;

public interface IPratoUseCase
{
    Task<ResponsePratoRegistradoJson> Salvar(RequestSalvarPratoJson pedido);
    Task<List<ResponsePratoJson>> Listar();
    Task<bool> Deletar(int idPedido);
}
