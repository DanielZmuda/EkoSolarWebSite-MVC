
namespace SolarSite.Services
{
    public interface IPvCalculator
    {
        double CalculatedPvPower(string lokalizacja, int moc, int katpolozenia, string katodchylenia);
    }
}
