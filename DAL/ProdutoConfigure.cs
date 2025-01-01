using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroClientes.DAL;

public class ProdutoConfigure : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> modelBuilder)
    {
        modelBuilder.HasKey(p => p.IdProduto);

        modelBuilder
            .HasOne(p => p.Categoria)
            .WithMany()
            .HasForeignKey(p => p.IdCategoria)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
