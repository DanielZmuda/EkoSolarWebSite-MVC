using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SolarSite.Data.Entities;
using SolarSite.Entities;

namespace SolarSite.PvPanelsDbContext
{
    public class PvPanelsContext : IdentityDbContext<StoreUser>
    {
        public PvPanelsContext(DbContextOptions<PvPanelsContext> options) : base(options)
        {

        }
        public DbSet<PvPanels> PvPanels { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<SolarRadiation> SolarRadiations {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


        }
    }
}
