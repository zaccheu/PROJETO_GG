using System.ComponentModel.DataAnnotations.Schema;

[Table("Cliente")]
public class Cliente
{
    [Column("IdCliente")]
    public int IdCliente { get; set; }

    [Column("Nome")]
    public string Nome { get; set; }

    [Column("Telefone")]
    public string Telefone { get; set; }

    [Column("Instagram")]
    public string Instagram { get; set; }

    [Column("VIP")]
    public bool VIP { get; set; }

    [Column("SEXO")]
    public string SEXO { get; set; }

    [Column("Ativo")]
    public bool Ativo { get; set; }
}