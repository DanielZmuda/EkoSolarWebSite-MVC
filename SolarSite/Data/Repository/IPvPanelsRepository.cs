using SolarSite.Data.Entities;
using SolarSite.Entities;
using System.Collections.Generic;

namespace SolarSite.Data.Repository
{
    public interface IPvPanelsRepository
    {
        IEnumerable<PvPanels> GetAll();
        IEnumerable<PvPanels> GetByType(string type);
        IEnumerable<SolarRadiation> GetPropertyValue(int month);
        bool SaveAll();
    }
}