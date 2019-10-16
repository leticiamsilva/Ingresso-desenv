using aplicacaodescontos.Domain;
using aplicacaodescontos.Services.Interface;
using aplicacaodescontos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace aplicacaodescontos.Services
{
    public class PromocaoService : IPromocaoService
    {
        //Nesse caso, faria uma tabela de ligação entre Promocode e Promocao
        public PromocaoViewModel GetPromocaoViewModelByPromocode(List<PromocaoViewModel> promocoesViewModel, string promocode)
        {
            foreach(var promocaoVM in promocoesViewModel)
            {
                if (promocaoVM.Promocodes.Any(p => p == promocode))
                    return promocaoVM;
            }

            throw new Exception("Nao ha promocoes para o promocode");
        }

        public PromocaoViewModel GetPromocaoViewModelByPromocodeMOCK()
        {
            var promocaoViewModel = new PromocaoViewModel
            {
                DescricaoPromocao = "Desconto sobre maior ingresso",
                Nome = "Final de semana é dia de cinema!",
                Promocodes = new List<string>(),
                Restricao = "Apenas para as sessões de sábado e domingo",
                Sigla = "FDS", //COR- ING9
                ValorDesconto = 12.50
            };
            promocaoViewModel.Promocodes.Add("YsnPvmhm");
            promocaoViewModel.Promocodes.Add("AdPRtqzw");
            promocaoViewModel.Promocodes.Add("MxNxhm3q");

            return promocaoViewModel;
        }

        public Carrinho AtualizaCarrinhoComPromocao(PromocaoViewModel promocaoViewModel, Carrinho carrinho)
        {
            switch(promocaoViewModel.Sigla)
            {
                case "FDS":
                    return AplicaPromocaoFDS(promocaoViewModel, carrinho);

                case "COR":
                    return AplicaPromocaoCOR();

                case "ING9":
                    return AplicaPromocaoING9();

                default:
                    return carrinho; 
            }
            
        }

        private Carrinho AplicaPromocaoING9()
        {
            throw new NotImplementedException();
        }

        private Carrinho AplicaPromocaoCOR()
        {
            throw new NotImplementedException();
        }

        private Carrinho AplicaPromocaoFDS(PromocaoViewModel promocaoViewModel, Carrinho carrinho)
        {
            throw new NotImplementedException();
        }

        public Carrinho AtualizaCarrinhoComPromocaoMOCK()
        {
            return new Carrinho();
        }
    }
}
