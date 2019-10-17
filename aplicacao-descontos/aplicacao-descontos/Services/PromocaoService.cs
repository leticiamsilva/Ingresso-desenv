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

        public Carrinho AtualizarCarrinhoComPromocao(PromocaoViewModel promocaoViewModel, Carrinho carrinho)
        {
            switch(promocaoViewModel.Sigla)
            {
                case "FDS":
                    return AplicarPromocaoFDS(promocaoViewModel, carrinho);

                case "COR":
                    return AplicarPromocaoCOR(promocaoViewModel, carrinho);

                case "ING9":
                    return AplicarPromocaoING9(promocaoViewModel, carrinho);

                default:
                    return carrinho; 
            }
            
        }

        public Carrinho AtualizarCarrinhoComPromocaoMOCK()
        {
            return new Carrinho();
        }

        private Carrinho AplicarPromocaoING9(PromocaoViewModel promocaoViewModel, Carrinho carrinho)
        {
            var tickets = carrinho.Sessions.Tickets;

            var valorMenorIngresso = tickets.Min(p => p.Price);

            var ticketMenor = tickets.Where(t => t.Price == valorMenorIngresso).FirstOrDefault();
            ticketMenor.Price = AplicarDescontoNoPreco(ticketMenor.Price, promocaoViewModel.ValorDesconto);

            carrinho.TotalPrice = carrinho.Sessions.Tickets.Sum(t => t.Price); 

            return carrinho;
        }

        private Carrinho AplicarPromocaoCOR(PromocaoViewModel promocaoViewModel, Carrinho carrinho)
        {
            carrinho.TotalPrice = AplicarDescontoNoPreco(carrinho.TotalPrice, promocaoViewModel.ValorDesconto);

            return carrinho;
        }

        private Carrinho AplicarPromocaoFDS(PromocaoViewModel promocaoViewModel, Carrinho carrinho)
        {
            var diaDoFilme = carrinho.Sessions.Date.DayOfWeek;

            if (diaDoFilme == DayOfWeek.Saturday || diaDoFilme == DayOfWeek.Sunday)
            {
                var tickets = carrinho.Sessions.Tickets;

                var valorMaiorIngresso = tickets.Max(p => p.Price);

                var ticketMaior = tickets.Where(t => t.Price == valorMaiorIngresso).FirstOrDefault();
                ticketMaior.Price = AplicarDescontoNoPreco(ticketMaior.Price, promocaoViewModel.ValorDesconto);

                carrinho.TotalPrice = carrinho.Sessions.Tickets.Sum(t => t.Price);
            }

            return carrinho;
        }

        private double AplicarDescontoNoPreco(double price, double valorDesconto)
        {
            return price > valorDesconto ? price - valorDesconto : 0;
        }
    }
}
