using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CadastroClientes.Entity;

[Table("Categorias")]
public class Categoria
{
    [Column("IdCategoria")]// Indica que o banco controla o valor
    public int IdCategoria { get; set; }

    [Column("Nome")]
    public string Nome { get; set; }
}
