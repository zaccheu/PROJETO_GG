using System.ComponentModel.DataAnnotations.Schema;

namespace GG.Models
{
    [Table("Despesas")]
    public class Despesas
    {
        public int IdDespesa { get; set; }
        public float Valor { get; set; }
        //public datetime Data { get; set; }
        public string TipoDespesa { get; set; }
        public string Descricao { get; set; }
    }
}
