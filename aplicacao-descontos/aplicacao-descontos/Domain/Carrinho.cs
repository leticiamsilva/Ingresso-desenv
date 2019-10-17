using System;
using System.Runtime.Serialization;

namespace aplicacaodescontos.Domain
{
    [DataContract]
    public class Carrinho
    {
        [DataMember]
        public string _Id { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public double TotalPrice { get; set; } 
        [DataMember]
        public Session Sessions { get; set; }
        [DataMember]
        public string Promocode { get; set; }
    }
}
