using GG.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace GG.Infrastructure.DataAccess;

internal class GGDbContext : DbContext
{
    public GGDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<PedidoPrato> PedidoPrato { get; set; }
    public DbSet<PratoProduto> PratoProduto { get; set; }
    public DbSet<Prato> Prato { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Despesa> Despesas { get; set; }
}
