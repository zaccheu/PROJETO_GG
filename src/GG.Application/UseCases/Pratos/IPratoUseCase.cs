using GG.Communication.Requests;
using GG.Communication.Responses.Prato;

namespace GG.Application.UseCases.Pratos;

public interface IPratoUseCase
{
    Task<ResponsePratoRegistradoJson> Salvar(RequestSalvarPratoJson prato);
    Task<List<ResponsePratoJson>> Listar();
    Task<ResponsePratoJson?> ObterPorId(int idPrato);
    Task<ResponsePratoRegistradoJson> Atualizar(int idPrato, RequestSalvarPratoJson prato);
    Task<bool> Deletar(int idPrato);
}
