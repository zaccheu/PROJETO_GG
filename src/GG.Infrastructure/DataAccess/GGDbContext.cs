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
    public DbSet<Despesa> Despesas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<Fornece> Fornece { get; set; }
}
