using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using SolarSite.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSite.PvPanelsDbContext
{
    public class PvPanelsSeeder
    {
        private readonly PvPanelsContext _ctx;
        private readonly IWebHostEnvironment _hosting;

        public PvPanelsSeeder(PvPanelsContext ctx, IWebHostEnvironment hosting)
        {
            _ctx = ctx;
            _hosting = hosting;
        }
        
        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.PvPanels.Any())
            {
                //Sample Data
                var filepath = Path.Combine(_hosting.ContentRootPath,"PvPanels.json");
                var json = File.ReadAllText(filepath);
                var products = JsonConvert.DeserializeObject<IEnumerable<PvPanels>>(json);
                _ctx.PvPanels.AddRange(products);

                var order = _ctx.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if(order!= null)
                {
                    new OrderPvPanel()
                    {
                        PvPanel = products.First(),
                        Quantity = 5,
                        UnitPrice = 0
                    };
                };

                _ctx.SaveChanges();
            }
        }
    }
}
