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
        private readonly IPvCalculator _pvPowerCalculator;
        private readonly IPvPanelsRepository _repository;
        private readonly IMailService _mailService;

        public HomeController(ILogger<HomeController> logger, IPvCalculator pvPowerCalculator, IPvPanelsRepository repository, IMailService mailService)
        {
            _logger = logger;
            _pvPowerCalculator = pvPowerCalculator;
            _repository = repository;
            _mailService = mailService;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Send the email
                _mailService.SendMessage("daniel@gmail.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Wiadomość została wysłana";
                ModelState.Clear();
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
