using CadastroClientes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroClientes.DAL
{
    public class PedidoProdutoConfigure : IEntityTypeConfiguration<PedidoProduto>
    {
        public void Configure(EntityTypeBuilder<PedidoProduto> modelBuilder)
        {
            // Configuração da chave composta para PedidoProduto
            modelBuilder.HasKey(pp => new { pp.IdPedido, pp.IdProduto });

            // Relacionamento entre PedidoProduto e Pedido
            modelBuilder
                .HasOne(pp => pp.Pedido)
                .WithMany(p => p.PedidoProdutos)
                .HasForeignKey(pp => pp.IdPedido)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento entre PedidoProduto e Produto
            modelBuilder
                .HasOne(pp => pp.Produto)
                .WithMany()
                .HasForeignKey(pp => pp.IdProduto)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
