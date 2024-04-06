namespace CadastroClientes.Models
{
    public class Faturamento
    {
        public double valor { get; set; }
        public int mes { get; set; }
        public int ano { get; set; }
        public int idConta { get; set; }
        public string data { get; set; }
        public bool paga { get; set; }
    }
}
