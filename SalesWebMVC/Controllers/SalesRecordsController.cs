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
        private readonly SalesRecordService _salesRecordService;


        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SimpleSearch(DateTime? dataMinima, DateTime? dataMaxima)
        {
            if (!dataMinima.HasValue)
            {
                dataMinima = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!dataMaxima.HasValue)
            {
                dataMaxima = DateTime.Now;
            }
            ViewData["minDate"] = dataMinima.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = dataMaxima.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordService.FindByDateAsync(dataMinima, dataMaxima);
            return View(result);
        }
        public IActionResult GroupingSearch()
        {
            return View();
        }


    }
}
