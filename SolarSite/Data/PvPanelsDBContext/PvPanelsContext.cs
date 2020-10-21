using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SolarSite.Entities;

namespace SolarSite.PvPanelsDbContext
{
    public class PvPanelsContext : DbContext
    {
        public PvPanelsContext(DbContextOptions<PvPanelsContext>options) : base(options)
        {

        }
        public DbSet<PvPanels> PvPanels { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


        }
    }
}
