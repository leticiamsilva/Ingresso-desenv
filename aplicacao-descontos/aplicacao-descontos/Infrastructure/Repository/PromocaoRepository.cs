using aplicacaodescontos.Domain;
using aplicacaodescontos.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacaodescontos.Infrastructure.Repository
{
    public class PromocaoRepository : IPromocaoRepository
    {
        private readonly PromocaoContext _context;

        
        public IEnumerable<Promocao> GetPromocoes()
        {
            return _context.Promocoes.ToList();
        }

        public Promocao GetPromocaoByPromocode(string promocode)
        {
            int id = getPromocaoIDByPromocode(promocode);

            return _context.Promocoes.Find(id);
        }

        //Há uma tabela de ligação entre o ID da promoção e o Promocode
        public int getPromocaoIDByPromocode(string promocode)
        {
            StringBuilder querygetId = new StringBuilder();
            querygetId.AppendFormat("select IdPromocao from PromocodePromocao where promocode = '{0}'", promocode);

            var retornoSQL = querygetId.ToString();

            var id = Int32.Parse(retornoSQL);

            return id;
        }


        public Promocao GetPromocaoByPromocodeMOCK(string promocode)
        {
            var promocao = new Promocao
            {
                DescricaoPromocao = "Desconto sobre maior ingresso",
                Id = 1,
                Sigla = "FDS", //Crga - Ing
                ValorDesconto = 12.50
            };

            return promocao;
        }
    }
}
