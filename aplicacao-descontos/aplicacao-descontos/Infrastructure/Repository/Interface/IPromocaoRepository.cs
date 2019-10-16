using aplicacaodescontos.Domain;
using System;
using System.Collections.Generic;

namespace aplicacaodescontos.Infrastructure.Repository
{
    public interface IPromocaoRepository : IDisposable
    {
        IEnumerable<Promocao> GetPromocoes();        
    }
}
