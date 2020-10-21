using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SolarSite.Models
{
    public class PvPowerCalculatorModel
    {
        public string Lokalizacja { get; set; }
        public int KatPochylenia { get; set; }
        public int KatOdchylenia { get; set; }
        public int MocInstalacji { get; set; }


    }
}
