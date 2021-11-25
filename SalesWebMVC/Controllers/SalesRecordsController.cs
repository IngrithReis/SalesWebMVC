using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartamentService _departamentService;

        public SalesRecordsController(SellerService sellerService, DepartamentService departamentService)
        {
            _sellerService = sellerService;
            _departamentService = departamentService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SimpleSearch()
        {
            return View();
        }
        public IActionResult GroupingSearch()
        {
            return View();
        }


    }
}
