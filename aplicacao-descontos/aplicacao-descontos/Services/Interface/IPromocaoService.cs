using aplicacaodescontos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplicacaodescontos.Services.Interface
{
    public interface IPromocaoService
    {
        Carrinho AtualizaCarrinhoComPromocao(Promocao promocao, Carrinho carrinho);

        Carrinho AtualizaCarrinhoComPromocaoMOCK(Promocao promocao, Carrinho carrinho);
    }
}
