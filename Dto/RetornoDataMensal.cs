namespace CadastroClientes.Dto;

public class RetornoDataMensal
{
    public decimal FaturamentoMensal { get; set; }
    public List<FaturamentoCategoriaDto> FaturamentoCategoria { get; set; }
}
