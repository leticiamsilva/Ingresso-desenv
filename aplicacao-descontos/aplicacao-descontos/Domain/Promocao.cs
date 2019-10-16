
using System.ComponentModel.DataAnnotations;

namespace aplicacaodescontos.Domain
{
    public class Promocao
    {
        [Key]
        public int Id{ get; set; }
        public string Sigla { get; set; }
        public string DescricaoPromocao { get; set; }
        public string Nome { get; set; }
        public string Restricao { get; set; }        
        public double ValorDesconto { get; set; }        
        public string Promocodes { get; set; }
    }
}
