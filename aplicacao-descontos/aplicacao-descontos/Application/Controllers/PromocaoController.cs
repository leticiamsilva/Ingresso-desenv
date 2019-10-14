using aplicacaodescontos.Domain;
using aplicacaodescontos.Infrastructure.Context;
using aplicacaodescontos.Infrastructure.Repository;
using aplicacaodescontos.Services;
using aplicacaodescontos.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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

        //public PromocaoController(IPromocaoRepository promocaoRepository, IPromocaoService promocaoService)
        public PromocaoController(PromocaoContext promocaoContext)
        {
            _promocaoContext = promocaoContext;
        }



        //api/promocao
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _promocaoRepository = new PromocaoRepository();
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

            var promocao = _promocaoRepository.GetPromocaoByPromocodeMOCK(carrinho.Promocode);

            var carrinhoComDesconto = _promocaoService.AtualizaCarrinhoComPromocaoMOCK(promocao, carrinho);
            var valorTotal = carrinhoComDesconto.TotalPrice;
            return new string[] { promocao.DescricaoPromocao, valorTotal.ToString() };
            //return carrinhoComDesconto
        }

        

        // api/promocao/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

    }
}
