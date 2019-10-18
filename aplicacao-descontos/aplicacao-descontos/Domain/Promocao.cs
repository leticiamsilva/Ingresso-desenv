
using System.ComponentModel.DataAnnotations;

namespace aplicacaodescontos.Domain
{
    public class Promocao
    {
        [Key]
        public int Id{ get; set; }
        public string DescricaoAplicarPromocao { get; set; } //Aplicar valor sobre: maior, menor Ingresso ou valor total.
        public string SiglaAplicarPromocao { get; set; }
        public string Nome { get; set; }
        public string Promocodes { get; set; }
        public string Restricoes { get; set; }        
        public double ValorDesconto { get; set; } 
    }
}
