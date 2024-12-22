using System.ComponentModel.DataAnnotations.Schema;

[Table("Despesas")]
public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Instagram { get; set; }
    public string Sexo { get; set; }
    public bool VIP { get; set; }
}