using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarSite.Data.Repository;
using SolarSite.Entities;

namespace SolarSite.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PvPanelsController : Controller
    {
        private readonly IPvPanelsRepository _repository;
        private readonly ILogger<PvPanelsController> _logger;

        public PvPanelsController(IPvPanelsRepository repository, ILogger<PvPanelsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<PvPanels>> Get()
        {

            try 
            { 
                return Ok(_repository.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get panels: {ex}");
                return BadRequest("Failed to get panels");
            }
        }
    }
}
