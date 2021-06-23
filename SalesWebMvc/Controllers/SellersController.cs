using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //anotation para indicar que essa ação é de post e não de get
        [ValidateAntiForgeryToken] //previnir que minha aplicação sofra ataque CSRF
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller); //implementação da ação de inserir esse cara no banco de dados
            return RedirectToAction(nameof(Index)); //redirecionar minha requisição para ação index
        }
    }
}