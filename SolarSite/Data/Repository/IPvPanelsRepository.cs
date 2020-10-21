using SolarSite.Entities;
using System.Collections.Generic;

namespace SolarSite.Data.Repository
{
    public interface IPvPanelsRepository
    {
        IEnumerable<PvPanels> GetAll();
        IEnumerable<PvPanels> GetByType(string type);
        bool SaveAll();
    }
}