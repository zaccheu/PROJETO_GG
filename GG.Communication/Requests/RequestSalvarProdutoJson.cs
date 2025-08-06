namespace GG.Dto;

public class RequestSalvarProdutoJson
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public decimal? PrecoDescontado { get; set; }
    public int Quantidade { get; set; }
    public string? Descricao { get; set; }
    public string Categoria { get; set; }
}
