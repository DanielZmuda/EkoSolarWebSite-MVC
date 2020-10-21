using SolarSite.Entities;
using SolarSite.PvPanelsDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
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
                .OrderBy(p => p.Moc)
                .ToList();
        }

        public IEnumerable<PvPanels> GetByType(string type)
        {
            return _ctx.PvPanels
                .Where(p => p.Typ == type)
                .ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
