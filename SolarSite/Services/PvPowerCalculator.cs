using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSite.Services
{
    public class PvPowerCalculator : IPvPowerCalculator
    {
        private readonly ILogger<PvPowerCalculator> _logger;

        public PvPowerCalculator(ILogger<PvPowerCalculator> logger)
        {
            _logger = logger;
        }
        public int CalculatedPvPower(string lokalizacja, int moc, int katpolozenia, int katodchylenia)
        {
            int calculatedPower = moc * 1000;
            return calculatedPower;
        }
    }
}
