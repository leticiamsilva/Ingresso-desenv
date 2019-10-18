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
                Id = 1,
                DescricaoAplicarPromocao = "Desconto sobre maior ingresso",
                SiglaAplicarPromocao = "MAI",
                Nome = "Final de semana é dia de cinema!",
                Promocodes = new List<string>(),
                Restricoes = new List<Restricao>(),
                ValorDesconto = 12.50
            };
            promocaoViewModel.Promocodes.Add("YsnPvmhm");
            promocaoViewModel.Promocodes.Add("AdPRtqzw");
            promocaoViewModel.Promocodes.Add("MxNxhm3q");

            var restricao = new Restricao()
            {
                Id = 1,
                Nome = "Apenas para as sessões de sábado e domingo",
                Sigla = "FDS",
            };

            promocaoViewModel.Restricoes.Add(restricao);

            return promocaoViewModel;
        }

        public CarrinhoViewModel AtualizarCarrinhoComPromocao(PromocaoViewModel promocaoViewModel, CarrinhoViewModel carrinho)
        {
            carrinho.TotalPrice = carrinho.Sessions.Tickets.Sum(t => t.Price);

            bool promocaoValida = AplicarRestricoesPromocao(carrinho, promocaoViewModel.Restricoes);

            if(promocaoValida)
            {
                switch(promocaoViewModel.SiglaAplicarPromocao)
                {
                    case "MEN":
                        return AplicarDescontoIngresso(promocaoViewModel, carrinho, promocaoViewModel.SiglaAplicarPromocao);

                    case "MAI":
                        return AplicarDescontoIngresso(promocaoViewModel, carrinho, promocaoViewModel.SiglaAplicarPromocao);

                    case "TOT":
                        carrinho.TotalPrice = AplicarDescontoNoPreco(carrinho.Sessions.Tickets.Sum(t=>t.Price), promocaoViewModel.ValorDesconto);
                        break;
                }
            }
            
            return carrinho;
        }

        private bool AplicarRestricoesPromocao(CarrinhoViewModel carrinho, List<Restricao> restricoes)
        {


            if (restricoes == null || !restricoes.Any())
                return true;

            foreach (var r in restricoes)
            {
                   switch(r.Sigla)
                   {

                    case "FDS":
                        if(!ValidarFDS(carrinho.Sessions.Date))
                            return false;
                        break;

                    case "F": //Event
                        if (!ValidarAssociado(carrinho.Sessions.Event.Id, r.AssociadoId))
                            return false;
                        break;

                    case "C": //Theatre
                        if  (!ValidarAssociado(carrinho.Sessions.Theatre.Id, r.AssociadoId))
                            return false;
                        break;

                    default:
                        break;
                   }
            }

            return true;
        }

        private bool ValidarAssociado(int id, int associadoId)
        {
            return id == associadoId;
        }

        public bool ValidarFDS(DateTime data)
        {
            return data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday;
        }


        public CarrinhoViewModel AtualizarCarrinhoComPromocaoMOCK()
        {
            return new CarrinhoViewModel();
        }

        private CarrinhoViewModel AplicarDescontoIngresso (PromocaoViewModel promocaoViewModel, CarrinhoViewModel carrinho, String tipoIngresso)
        {
            var tickets = carrinho.Sessions.Tickets;

            double valorIngresso = 0;

            switch (tipoIngresso)
            {
                case "MEN":
                    valorIngresso = tickets.Min(p => p.Price);
                    break;
                case "MAI":
                    valorIngresso = tickets.Max(p => p.Price);
                    break;
            }

            var ticketADescontar = tickets.Where(t => t.Price == valorIngresso).FirstOrDefault();

            ticketADescontar.Price = AplicarDescontoNoPreco(ticketADescontar.Price, promocaoViewModel.ValorDesconto);

            carrinho.TotalPrice = carrinho.Sessions.Tickets.Sum(t => t.Price); 

            return carrinho;
        }


        private double AplicarDescontoNoPreco(double price, double valorDesconto)
        {
            
            return price > valorDesconto ? price - valorDesconto : 0;
        }

    }
}
