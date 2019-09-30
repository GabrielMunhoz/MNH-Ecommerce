using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MNH_Ecommerce.Domain.Contrats;
using MNH_Ecommerce.MVC.Models;
using MNH_Ecommerce.Repository.Repositories;

namespace MNH_Ecommerce.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository context)
        {
            _productRepository = context;
        }

        public IActionResult Index()
        {

            return View(_productRepository.GetAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
