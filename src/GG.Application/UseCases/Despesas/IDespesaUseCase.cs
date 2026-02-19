using GG.Communication.Requests;
using GG.Communication.Responses.Despesa;

namespace GG.Application.UseCases.Despesas;

public interface IDespesaUseCase
{
    Task<ResponseDespesaRegistradaJson> Salvar(RequestSalvarDespesaJson despesa);
    Task<List<ResponseDespesaJson>> Listar();
    Task<bool> Deletar(int idDespesa);
    Task<ResponseDespesaJson> GetById(int idDespesa);
}
