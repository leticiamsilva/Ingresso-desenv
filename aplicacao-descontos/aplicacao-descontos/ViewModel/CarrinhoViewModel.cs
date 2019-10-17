using aplicacaodescontos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplicacaodescontos.ViewModel
{
    public class CarrinhoViewModel
    {
        public string _Id { get; set; }
        public DateTime Date { get; set; }
        public double TotalPrice { get; set; }
        public Session Sessions { get; set; }
        public string Promocode { get; set; }
    }
}
