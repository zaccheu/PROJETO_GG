using GG.Communication.Requests;
using GG.Communication.Responses.Produto;

namespace GG.Application.UseCases.Produtos;

public interface IProdutoUseCase
{
    Task<ResponseProdutoRegistradoJson> Salvar(RequestSalvarProdutoJson produto);
    Task<List<ResponseProdutosJson>> Listar();
    Task<bool> Deletar(int idProduto);
}
