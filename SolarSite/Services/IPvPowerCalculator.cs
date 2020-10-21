using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSite.Services
{
    public interface IPvPowerCalculator
    {
        int CalculatedPvPower(string lokalizacja, int moc, int katpolozenia, int katodchylenia);
    }
}
