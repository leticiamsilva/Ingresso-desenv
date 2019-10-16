using System.Collections.Generic;

namespace aplicacaodescontos.ViewModel
{
    public class PromocaoViewModel
    {
        public int Id { get; set; }
        public string Sigla { get; set; }
        public string DescricaoPromocao { get; set; }
        public string Nome { get; set; }
        public string Restricao { get; set; }
        public double ValorDesconto { get; set; }
        public List<string> Promocodes { get; set; }
    }
}
