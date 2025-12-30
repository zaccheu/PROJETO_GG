using GG.Communication.Responses;
using GG.Dto;

namespace GG.Application.UseCases.Produtos;

public interface IProdutoUseCase
{
    Task <ResponseProdutosRegistradosJson> Salvar(RequestSalvarProdutoJson produto);
    Task <List<ResponseProdutosJson>> Listar();
    Task<bool> Deletar(int idProduto);
}
