using GG.Domain.Entity;

namespace GG.Domain.Repositories.Produtos;

public interface IProdutoRepository
{
    Task Add(Produto pedido);
    Task <bool> Delete(int idProduto);
    Task <List<Produto>> GetAll();
}
