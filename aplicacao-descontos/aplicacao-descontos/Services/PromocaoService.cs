using aplicacaodescontos.Domain;
using aplicacaodescontos.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplicacaodescontos.Services
{
    public class PromocaoService : IPromocaoService
    {
        public Carrinho AtualizaCarrinhoComPromocao(Promocao promocao, Carrinho carrinho)
        {
            return new Carrinho();
        }

        public Carrinho AtualizaCarrinhoComPromocaoMOCK(Promocao promocao, Carrinho carrinho)
        {
            return new Carrinho();
        }
    }
}
