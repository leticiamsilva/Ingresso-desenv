using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace aplicacaodescontos.Domain
{
    [DataContract]
    public class Carrinho
    {
        [DataMember]
        int Id { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public double TotalPrice { get; set; }
        [DataMember]
        public string Promocode { get; set; }
        [DataMember]
        public Session Sessions { get; set; }


        public double GetDesconto (Promocao promocao)
        {            
            
            if(!VerificarAplicacaoDesconto(promocao, this.Sessions))
                return 0;

            return 20;
        }

        private bool VerificarAplicacaoDesconto(Promocao promocao, Session session)
        {

            if (promocao.Sigla.Equals("FDS")) //se for fds, verificar o dia do filme
            {
                var diaDoFilme = session.DateSession.DayOfWeek;
                return (diaDoFilme == DayOfWeek.Saturday || diaDoFilme == DayOfWeek.Sunday);
            }

            return true;
        }

        public double GetValorTotalCompra(Promocao promocao)
        {

            return 30;
        }
    }
}
