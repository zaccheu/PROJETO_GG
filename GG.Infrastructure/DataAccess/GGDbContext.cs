using GG.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace GG.Infrastructure.DataAccess;
internal class GGDbContext : DbContext
{
    public GGDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
}
