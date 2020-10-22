using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using SolarSite.Data.Entities;
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
        private readonly UserManager<StoreUser> _userManager;

        public PvPanelsSeeder(PvPanelsContext ctx, IWebHostEnvironment hosting, UserManager<StoreUser> userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }
        
        public async Task SeedAsync()
        {
            _ctx.Database.EnsureCreated();

            StoreUser user = await _userManager.FindByEmailAsync("daniel@gmail.com");
            if (user == null)
            {
                
                user = new StoreUser()
                {
                    FirstName = "Daniel",
                    LastName = "Zmuda",
                    Email = "daniel@gmail.com",
                    UserName = "daniel@gmail.com"
                };

                var result = await _userManager.CreateAsync(user, "P@ssword1");
                if(result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not recive new user in seeder");
                }
            }
            if (!_ctx.SolarRadiations.Any())
            {
                var filepath = Path.Combine(_hosting.ContentRootPath, "daneNaslonecznienie.json");
                var json = File.ReadAllText(filepath);
                var products = JsonConvert.DeserializeObject<IEnumerable<SolarRadiation>>(json);
                _ctx.SolarRadiations.AddRange(products);
            }

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
                    order.User = user;
                    order.Items = new List<OrderPvPanel>();
                    {
                        new OrderPvPanel()
                        {
                            PvPanel = products.First(),
                            Quantity = 5,
                            UnitPrice = 0
                        };
                    };
                };

                _ctx.SaveChanges();
            }
        }
    }
}
