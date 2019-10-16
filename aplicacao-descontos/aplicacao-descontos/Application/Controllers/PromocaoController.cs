using aplicacaodescontos.Domain;
using aplicacaodescontos.Infrastructure.Context;
using aplicacaodescontos.Infrastructure.Repository;
using aplicacaodescontos.Services;
using aplicacaodescontos.Services.Interface;
using aplicacaodescontos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        //api/promocao
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _promocaoService = new PromocaoService();

            var carrinho = new Carrinho
            {
                Promocode = "MxNxhm3q",
                Sessions = new Session
                {
                    DateSession = new DateTime(2019, 10, 29),
                    Tickets = null,
                    Event = null, 
                    Theatre = null
                }
            };

            var promocoesViewModel = ConverterMaisDeUmaPromocaoParaPromocaoViewModel(_promocaoContext.Promocao.ToList<Promocao>());

            var promocaoViewModel = _promocaoService.GetPromocaoViewModelByPromocode(promocoesViewModel, carrinho.Promocode);

            var carrinhoComDesconto = _promocaoService.AtualizaCarrinhoComPromocao(promocaoViewModel, carrinho);
            var valorTotal = carrinhoComDesconto.TotalPrice;

            return new string[] { promocaoViewModel.DescricaoPromocao, valorTotal.ToString() };
            //return carrinhoComDesconto.serializable()
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
                DescricaoPromocao = promocao.DescricaoPromocao,
                Nome = promocao.Nome,
                Promocodes = promocao.Promocodes.Split(',').Select(p => p.Trim()).ToList(),
                Restricao = promocao.Restricao,
                Sigla = promocao.Sigla,
                ValorDesconto = promocao.ValorDesconto
            };

            return promocaoViewModel;
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
