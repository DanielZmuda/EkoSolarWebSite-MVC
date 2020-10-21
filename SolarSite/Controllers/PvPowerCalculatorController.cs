using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SolarSite.Data.Repository;

namespace SolarSite.Controllers
{
    public class PvPowerCalculatorController : Controller
    {
        private readonly IPvPanelsRepository _repository;

        public PvPowerCalculatorController(IPvPanelsRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
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
    }
}
