using System;

namespace SolarSite.Entities
{
    public class PvPanels
    {
        public int Id { get; set; }
        public String Manufacturer{ get; set; }
        public Double Power{ get; set; }
        public String Type { get; set; }
        public Double Height { get; set; }
        public Double Width { get; set; }
        public Double Thickness { get; set; }
        public Double Weight { get; set; }
        public Double Performance { get; set; }
        public String Photo { get; set; }
    }
}
