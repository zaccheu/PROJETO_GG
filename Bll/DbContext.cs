using CadastroClientes.Models;
using Microsoft.EntityFrameworkCore;

public class MeuDbContext : DbContext
{
    public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
    {
    }

    // DbSets representam as tabelas do banco
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Produto> Pratos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurações adicionais (opcional)
        modelBuilder.Entity<Cliente>().HasKey(p => p.IdCliente);
        modelBuilder.Entity<Produto>().HasKey(p => p.IdProduto);
    }
}
