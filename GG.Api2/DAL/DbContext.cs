using GG.DAL;
using GG.Domain.Entities;
using GG.Domain.Entity;
using GG.Entity;
using GG.Models;
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
    public DbSet<Categoria> Categorias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cliente>()
            .HasKey(c => c.IdCliente);
        modelBuilder.Entity<Produto>()
            .HasKey(p => p.IdProduto);
        modelBuilder.Entity<Pedido>()
            .HasKey(p => p.IdPedido);
        modelBuilder.Entity<Categoria>()
            .HasKey(c => c.IdCategoria);

        modelBuilder.ApplyConfiguration(new PedidoProdutoConfigure());
        modelBuilder.ApplyConfiguration(new ProdutoConfigure());
    }
}
