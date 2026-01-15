using GG.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace GG.Infrastructure.DataAccess;

internal class GGDbContext : DbContext
{
    public GGDbContext(DbContextOptions<GGDbContext> options) : base(options) { }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<PedidoPrato> PedidoPrato { get; set; }
    public DbSet<PratoProduto> PratoProduto { get; set; }
    public DbSet<Prato> Pratos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Despesa> Despesas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<Fornece> Fornece { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração da chave composta para Fornece
        modelBuilder.Entity<Fornece>()
            .HasKey(f => new { f.IdFornecedor, f.IdProduto });

        // Configuração da chave composta para PedidoPrato
        modelBuilder.Entity<PedidoPrato>()
            .HasKey(pp => new { pp.IdPedido, pp.IdPrato });

        modelBuilder.Entity<PedidoPrato>()
            .HasOne(pp => pp.Pedido)
            .WithMany(p => p.PedidoPratos)
            .HasForeignKey(pp => pp.IdPedido);

        modelBuilder.Entity<PedidoPrato>()
            .HasOne(pp => pp.Prato)
            .WithMany(p => p.PedidoPratos)
            .HasForeignKey(pp => pp.IdPrato);

        // Configuração da chave composta para PratoProduto
        modelBuilder.Entity<PratoProduto>()
            .HasKey(pp => new { pp.IdPrato, pp.IdProduto });

        modelBuilder.Entity<PratoProduto>()
            .HasOne(pp => pp.Prato)
            .WithMany(p => p.PratoProdutos)
            .HasForeignKey(pp => pp.IdPrato);

        modelBuilder.Entity<PratoProduto>()
            .HasOne(pp => pp.Produto)
            .WithMany(p => p.PratoProdutos)
            .HasForeignKey(pp => pp.IdProduto);

        // Configuração de precisão para decimal
        modelBuilder.Entity<Pedido>()
            .Property(p => p.Valor)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Prato>()
            .Property(p => p.Preco)
            .HasPrecision(18, 2);

        modelBuilder.Entity<PedidoPrato>()
            .Property(pp => pp.Preco)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Despesa>()
            .Property(d => d.Valor)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Produto>()
            .Property(p => p.Preco)
            .HasPrecision(18, 2);
    }
}
