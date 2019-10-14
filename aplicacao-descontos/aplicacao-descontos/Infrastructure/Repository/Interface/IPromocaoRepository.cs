using aplicacaodescontos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplicacaodescontos.Infrastructure.Repository
{
    public interface IPromocaoRepository
    {
        IEnumerable<Promocao> GetPromocoes();
        Promocao GetPromocaoByPromocode(string promocode);
        Promocao GetPromocaoByPromocodeMOCK(string promocode);
    }
}
