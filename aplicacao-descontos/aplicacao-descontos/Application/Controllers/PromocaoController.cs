using aplicacaodescontos.Domain;
using aplicacaodescontos.Infrastructure.Context;
using aplicacaodescontos.Infrastructure.Repository;
using aplicacaodescontos.Services;
using aplicacaodescontos.Services.Interface;
using aplicacaodescontos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace aplicacaodescontos.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocaoController : Controller
    {
        private static List<Promocao> listaPromocao = new List<Promocao>();

        private PromocaoContext _promocaoContext;
        private IPromocaoRepository _promocaoRepository;
        private IPromocaoService _promocaoService;

        public PromocaoController(PromocaoContext promocaoContext)
        {
            _promocaoContext = promocaoContext;
            _promocaoRepository = new PromocaoRepository(promocaoContext);
        }

        [AcceptVerbs("GET")]
        [Route("CarrinhoDesconto")]
        public IEnumerable<string> CarrinhoDesconto (string carrinhoReq)
        {
            Carrinho carrinho = JsonConvert.DeserializeObject<Carrinho>(carrinhoReq);

            _promocaoService = new PromocaoService();

            //Os promocodes foram inseridos no banco em uma mesma célula.
            var promocoesViewModel = ConverterMaisDeUmaPromocaoParaPromocaoViewModel(_promocaoContext.Promocao.ToList<Promocao>());

            var promocaoViewModel = _promocaoService.GetPromocaoViewModelByPromocode(promocoesViewModel, carrinho.Promocode);

            var carrinhoViewModel = ConverterCarrinhoParaCarrinhoViewModel(carrinho);

            var carrinhoComDesconto = _promocaoService.AtualizarCarrinhoComPromocao(promocaoViewModel, carrinhoViewModel);

            return new string[] { carrinhoComDesconto.TotalPrice.ToString(), promocaoViewModel.Nome };

            //return Json(carrinhoViewModel);
        }

        //api/promocao
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Api Aplica Desconto" };
        }

        private CarrinhoViewModel ConverterCarrinhoParaCarrinhoViewModel(Carrinho carrinho)
        {
            return new CarrinhoViewModel()
            {
                _Id = carrinho._Id,
                Date = carrinho.Date,
                Promocode = carrinho.Promocode,
                Sessions = carrinho.Sessions,
                TotalPrice = carrinho.TotalPrice
            };
        }

        private List<PromocaoViewModel> ConverterMaisDeUmaPromocaoParaPromocaoViewModel(List<Promocao> promocoes)
        {
            var promocoesViewModel = new List<PromocaoViewModel>();
            foreach(var promocao in promocoes)
            {
                promocoesViewModel.Add(ConverterPromocaoParaViewModel(promocao));
            }

            return promocoesViewModel;
        }

        private PromocaoViewModel ConverterPromocaoParaViewModel(Promocao promocao)
        {
            var promocaoViewModel = new PromocaoViewModel
            {
                Id = promocao.Id,
                DescricaoAplicarPromocao = promocao.DescricaoAplicarPromocao,
                SiglaAplicarPromocao = promocao.SiglaAplicarPromocao,
                Nome = promocao.Nome,
                Promocodes = promocao.Promocodes.Split(',').Select(p => p.Trim()).ToList(),
                Restricoes = RecuperaRestricoes(promocao.Restricoes),
                ValorDesconto = promocao.ValorDesconto
            };

            return promocaoViewModel;
        }

        private List<Restricao> RecuperaRestricoes(string restricoes)
        {

          var listaRestricoes = new List<Restricao>();

            if (!String.IsNullOrEmpty(restricoes))
            {
                var restricoesAAplicar = restricoes.Split(',').Select(r => r.Trim()).ToList();

                foreach (string restricao in restricoesAAplicar)
                {
                    int idRestricao = int.Parse(restricao);
                    listaRestricoes.Add(_promocaoContext.Restricao.Where(r => r.Id == idRestricao).FirstOrDefault());
                }
            }

            return listaRestricoes;
        }

        public IActionResult Index(int id)
        {
            return View();
        }
        

        // api/promocao/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        protected override void Dispose(bool disposing)
        {
            _promocaoRepository.Dispose();
            base.Dispose(disposing);
        }

    }
}
