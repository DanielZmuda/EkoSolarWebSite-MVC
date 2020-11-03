using SolarSite.Data.Entities;
using System;
using System.Collections.Generic;

namespace SolarSite.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public String OrderNumber { get; set; }
        public ICollection<OrderPvPanel> Items { get; set; }
        public StoreUser User { get; set; }
    }
}
