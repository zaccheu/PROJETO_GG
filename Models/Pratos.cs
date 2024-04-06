using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CadastroClientes.Models
{
    public class Pratos
    {
        public string nome { get; set; }
        public int idProduto { get; set; }
        public double preço { get; set; }
    }
}
