using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroClientes.Models
{
    [Table("PedidoProdutos")]
    public class PedidoProduto
    {
        [Column("IdPedido")]
        public int IdPedido { get; set; }
        public virtual Pedido Pedido { get; set; }

        [Column("IdProduto")]
        public int IdProduto { get; set; }
        public virtual Produto Produto { get; set; }

        [Column("Quantidade")] 
        public int Quantidade { get; set; }
    }
}
