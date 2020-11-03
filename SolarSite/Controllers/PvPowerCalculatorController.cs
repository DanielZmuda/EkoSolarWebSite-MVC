using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolarSite.Data.Repository;
using SolarSite.Models;
using SolarSite.Services;

namespace SolarSite.Controllers
{
    public class PvPowerCalculatorController : Controller
    {
        private readonly IPvPanelsRepository _repository;
        private readonly IPvCalculator _pvPowerCalculator;

        public PvPowerCalculatorController(IPvPanelsRepository repository, IPvCalculator pvPowerCalculator)
        {
            _repository = repository;
            _pvPowerCalculator = pvPowerCalculator;
        }

        [HttpPost]
        public IActionResult PvCalculator(PvCalculatorModel model)
        {
            if (ModelState.IsValid)
            {

                Console.WriteLine("Obliczanie wygenerowanej energii instalacji");
                @ViewBag.UserMessage = "Twoja instalacja w ciągu wygeneruje: " + _pvPowerCalculator.CalculatedPvPower(model.Localization, model.InstalationPower, model.TiltAngle, model.SurfaceDirection) +  " kWh energi elektrycznej w ciągu roku!!!";
            }
            else
            {

            }
            return View();
        }

        [Authorize]
        public IActionResult Shop(string sortorder)
        {
            if (sortorder != null)
            {
                var results = _repository.GetByType(sortorder);
                return View(results.ToList());
            } else
            {
                var results = _repository.GetAll();
                return View(results.ToList());
            }
        }
        public IActionResult PvCalculator()
        {

            return View();
        }
    }
}
