namespace GG.Communication.Requests;

public class RequestSalvarProdutoJson
{
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public string UnidadeMedida { get; set; } = string.Empty;
}
