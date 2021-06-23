using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService; //declarãção de dependencia

        public SellersController(SellerService sellerService) //construtor com injeção de dependencia
        {
            _sellerService = sellerService;
        }
        public IActionResult Index() //chamada do conhtrolador, pegando o model e encaminhando os dados para a view
        {
            //implementação do _sellerService.FindAll
            var list = _sellerService.FindAll();
            return View(list);
        }
    }
}