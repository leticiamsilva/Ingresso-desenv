using aplicacaodescontos.Domain;
using System.Collections.Generic;

namespace aplicacaodescontos.ViewModel
{
    public class PromocaoViewModel
    {
        public int Id { get; set; }
        public string DescricaoAplicarPromocao { get; set; }
        public string SiglaAplicarPromocao { get; set; }
        public string Nome { get; set; }
        public List<string> Promocodes { get; set; }
        public List<Restricao> Restricoes { get; set; }
        public double ValorDesconto { get; set; }
    }
}
