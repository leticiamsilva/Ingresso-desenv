using aplicacaodescontos.Domain;
using aplicacaodescontos.ViewModel;
using System.Collections.Generic;

namespace aplicacaodescontos.Services.Interface
{
    public interface IPromocaoService
    {
        PromocaoViewModel GetPromocaoViewModelByPromocode(List<PromocaoViewModel> promocoes, string promocode);

        PromocaoViewModel GetPromocaoViewModelByPromocodeMOCK();

        Carrinho AtualizarCarrinhoComPromocao(PromocaoViewModel promocaoViewModel, Carrinho carrinho);

        Carrinho AtualizarCarrinhoComPromocaoMOCK();
    }
}
