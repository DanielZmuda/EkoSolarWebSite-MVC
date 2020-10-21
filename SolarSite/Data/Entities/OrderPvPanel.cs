using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSite.Entities
{
    public class OrderPvPanel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public  PvPanels PvPanel { get; set; }
        public decimal UnitPrice { get; set; }
        public Order Order { get; set; }
    }
}
