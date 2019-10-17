using aplicacaodescontos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplicacaodescontos.ViewModel
{
    public class CarrinhoViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }            
        public string Promocode { get; set; }
        public Session Sessions { get; set; }

        public double TotalPrice
        {
            get { return Sessions.Tickets.Sum(t => t.Price); }
        }


    }
}
