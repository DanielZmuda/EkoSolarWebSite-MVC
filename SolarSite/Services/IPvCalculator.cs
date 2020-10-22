using SolarSite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSite.Services
{
    public interface IPvCalculator
    {
        double CalculatedPvPower(string lokalizacja, int moc, int katpolozenia, string katodchylenia);
    }
}
