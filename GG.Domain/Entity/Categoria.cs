using System.ComponentModel.DataAnnotations.Schema;

namespace GG.Domain.Entity;

[Table("Categorias")]
public class Categoria
{
    [Column("IdCategoria")]// Indica que o banco controla o valor
    public int IdCategoria { get; set; }

    [Column("Nome")]
    public string Nome { get; set; }

    [Column("Descricao")]
    public string Descricao { get; set; }
}
