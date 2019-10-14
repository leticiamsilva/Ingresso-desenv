using aplicacaodescontos.Domain;
using System;
using System.Collections.Generic;

namespace aplicacaodescontos.Domain
{
    public class Session
    {
      public DateTime DateSession { get; set; }

      public  Event Event { get; set; }

      public Theatre Theatre { get; set; }

      public IList<Ticket> Tickets { get; set; }

    }
}
