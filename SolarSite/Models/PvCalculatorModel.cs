using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SolarSite.Models
{
    public class PvCalculatorModel
    {
        public string Localization { get; set; }
        public int TiltAngle { get; set; }
        public string SurfaceDirection { get; set; }
        public int InstalationPower { get; set; }

    }
}
