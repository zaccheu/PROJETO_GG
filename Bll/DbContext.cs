using CadastroClientes.Models;
using Microsoft.EntityFrameworkCore;

public class MeuDbContext : DbContext
{
    public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
    {
    }

    // DbSets representam as tabelas do banco
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<PedidoProduto> PedidoProduto { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cliente>()
            .HasKey(c => c.IdCliente);
        modelBuilder.Entity<Produto>()
            .HasKey(p => p.IdProduto);
        modelBuilder.Entity<Pedido>()
            .HasKey(p => p.IdPedido);

        // Configuração do relacionamento entre PedidoProduto e Pedido
        modelBuilder.Entity<PedidoProduto>()
            .HasKey(pp => new { pp.IdPedido, pp.IdProduto });  // Chave composta

        modelBuilder.Entity<PedidoProduto>()
            .HasOne(pp => pp.Pedido)
            .WithMany(p => p.PedidoProdutos)
            .HasForeignKey(pp => pp.IdPedido)
            .OnDelete(DeleteBehavior.Cascade);  // Deleta produtos quando o pedido for deletado

        modelBuilder.Entity<PedidoProduto>()
            .HasOne(pp => pp.Produto)
            .WithMany()  // Não precisa de navegação de volta em Produto
            .HasForeignKey(pp => pp.IdProduto)
            .OnDelete(DeleteBehavior.Cascade);  // Comportamento similar para Produto
    }
}
