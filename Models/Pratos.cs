using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CadastroClientes.Models
{
    public class Produtos
    {

        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }
        public string Descricao { get; set; }
    }
}
