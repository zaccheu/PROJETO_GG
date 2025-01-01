using CadastroClientes.Entity;

namespace CadastroClientes.Dto;

public class FaturamentoCategoriaDto
{
    public Categoria Categoria { get; set; }
    public decimal Faturamento { get; set; }
}
