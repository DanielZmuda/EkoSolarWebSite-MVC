using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSite.Entities
{
    public class PvPanels
    {
        public int Id { get; set; }
        public String Producent { get; set; }
        public Double Moc { get; set; }
        public String Typ { get; set; }
        public Double Wysokosc { get; set; }
        public Double Szerokosc { get; set; }
        public Double Grubosc { get; set; }
        public Double Waga { get; set; }
        public Double Wydajnosc { get; set; }
        public String Zdjecie { get; set; }
    }
}
