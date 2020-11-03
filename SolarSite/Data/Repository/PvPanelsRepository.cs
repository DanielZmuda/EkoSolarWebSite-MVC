using SolarSite.Data.Entities;
using SolarSite.Entities;
using SolarSite.PvPanelsDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SolarSite.Data.Repository
{
    public class PvPanelsRepository : IPvPanelsRepository
    {
        private readonly PvPanelsContext _ctx;

        public PvPanelsRepository(PvPanelsContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<PvPanels> GetAll()
        {
            return _ctx.PvPanels
                .OrderBy(p => p.Power)
                .ToList();
        }

        public IEnumerable<PvPanels> GetByType(string type)
        {
            return _ctx.PvPanels
                .Where(p => p.Type == type)
                .ToList();
        }
        public IEnumerable<SolarRadiation> GetPropertyValue(int month)
        {
            return _ctx.SolarRadiations.Where(p => p.Id == month).ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
