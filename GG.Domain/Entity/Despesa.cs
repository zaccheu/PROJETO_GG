using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GG.Domain.Entity;

[Table("Despesas")]
public class Despesa
{
    [Key]
    [Column("IdDespesa")]
    public int IdDespesa { get; set; }

    [Column("Descricao")]
    public string Descricao { get; set; }

    [Column("Valor")]
    public decimal Valor { get; set; }

    [Column("Data")]
    public DateTime Data { get; set; }

    [Column("Fixa")]
    public bool Fixa { get; set; }

    [Column("Nome")]
    public string? Nome { get; set; }
}