using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSite.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public String OrderNumber { get; set; }
        public ICollection<OrderPvPanel> Items { get; set; }
    }
}
