using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarSite.Data.Repository;
using SolarSite.Models;

using SolarSite.Services;

namespace SolarSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPvPowerCalculator _pvPowerCalculator;
        private readonly IPvPanelsRepository _repository;

        public HomeController(ILogger<HomeController> logger, IPvPowerCalculator pvPowerCalculator, IPvPanelsRepository repository)
        {
            _logger = logger;
            _pvPowerCalculator = pvPowerCalculator;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Inverters()
        {
            return View();
        }
        public IActionResult PvPowerCalculator()
        {
            
            return View();
        }



        [HttpPost]
        public IActionResult PvPowerCalculator(PvPowerCalculatorModel model)
        {
            if(ModelState.IsValid)
            {
                Console.WriteLine("Obliczanie wygenerowanej energii instalacji");
                @ViewBag.UserMessage= "Twoja instalacja w ciągu wygeneruje: " + _pvPowerCalculator.CalculatedPvPower(model.Lokalizacja, model.MocInstalacji, model.KatPochylenia, model.KatOdchylenia) + "kWh energi elektrycznej w ciągu roku !!!";
            }else
            {

            }
            return View();
        }
        public IActionResult PvPanels()
        {
            var results = _repository.GetAll();


            return View(results.ToList());
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
