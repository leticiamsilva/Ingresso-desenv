using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplicacaodescontos.Domain
{
    public class Promocao
    {
        public int Id { get; set; }
        public string DescricaoPromocao { get; set; }
        public string Sigla { get; set; }
        public double ValorDesconto { get; set; }
        public bool Restricao { get { return !String.IsNullOrEmpty(Sigla); } }
    }
}
