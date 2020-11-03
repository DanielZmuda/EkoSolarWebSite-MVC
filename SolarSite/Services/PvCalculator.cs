using Microsoft.Extensions.Logging;
using SolarSite.Data.Repository;
using System;
using System.Text;

namespace SolarSite.Services
{
    public class PvCalculator : IPvCalculator
    {
        private readonly ILogger<PvCalculator> _logger;
        private readonly IPvPanelsRepository _repository;

        public PvCalculator(ILogger<PvCalculator> logger, IPvPanelsRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public double CalculatedPvPower(string localization, int mocInstalacji, int katpolozenia, string katodchylenia)
        {
            //nateżenie promieniowanai slonecznego Wh/m2
            double solarRadiation = 0;
            double panelPerformacne= 0.16;
            double panelPower = 0.285;
            double panelSurface = (mocInstalacji/panelPower) * 1.5;
            StringBuilder builder = new StringBuilder();
              builder.Append("I_N__" + katpolozenia);
            var type = builder.ToString();

            switch (localization)
            {
                case "Kraków":
                    solarRadiation += 1045532;
                    break;
                case "Warszawa":
                    solarRadiation += 977921;
                    break;
                case "Katowice":
                    solarRadiation += 1019689;
                    break;
                case "Gdansk":
                    solarRadiation += 900480;
                    break;
            }
            var powerFactor = CalculatePowerFactor(katpolozenia, katodchylenia);


            double calculatedPower = panelPerformacne*solarRadiation*panelSurface*powerFactor/1000;
            calculatedPower = Math.Round(calculatedPower); 

            return calculatedPower;
        }

        private double CalculatePowerFactor(int tiltFactor, string surfaceDirection)
        {
            double powerFactor=0;
            switch (surfaceDirection)
            {
                case "Południe":
                    if (tiltFactor < 25)
                    {
                       return powerFactor += 0.96;
                    }
                    if(tiltFactor>=25 && tiltFactor < 40)
                    {
                        return powerFactor += 0.98;
                    }
                    if (tiltFactor >= 40 && tiltFactor < 55)
                    {
                        return powerFactor += 1;
                    }
                    if (tiltFactor >= 55 && tiltFactor < 70)
                    {
                        return powerFactor += 0.9;
                    }
                    if (tiltFactor >= 70 && tiltFactor < 90)
                    {
                        return powerFactor += 0.80;
                    }
                    return powerFactor;
                 
                case "Wschód":
                    if (tiltFactor < 25)
                    {
                        return powerFactor += 0.96;
                    }
                    if (tiltFactor >= 25 && tiltFactor < 40)
                    {
                        return powerFactor += 0.98;
                    }
                    if (tiltFactor >= 40 && tiltFactor < 55)
                    {
                        return powerFactor += 1;
                    }
                    if (tiltFactor >= 55 && tiltFactor < 70)
                    {
                        return powerFactor += 0.9;
                    }
                    if (tiltFactor >= 70 && tiltFactor < 90)
                    {
                        return powerFactor += 0.80;
                    }
                    return powerFactor;
                    
                case "Zachód":
                    if (tiltFactor < 25)
                    {
                        return powerFactor += 0.96;
                    }
                    if (tiltFactor >= 25 && tiltFactor < 40)
                    {
                        return powerFactor += 0.98;
                    }
                    if (tiltFactor >= 40 && tiltFactor < 55)
                    {
                        return powerFactor += 1;
                    }
                    if (tiltFactor >= 55 && tiltFactor < 70)
                    {
                        return powerFactor += 0.9;
                    }
                    if (tiltFactor >= 70 && tiltFactor < 90)
                    {
                        return powerFactor += 0.80;
                    }
                    return powerFactor;
                    
                case "Północ":
                    if (tiltFactor < 25)
                    {
                        return powerFactor += 0.96;
                    }
                    if (tiltFactor >= 25 && tiltFactor < 40)
                    {
                        return powerFactor += 0.98;
                    }
                    if (tiltFactor >= 40 && tiltFactor < 55)
                    {
                        return powerFactor += 1;
                    }
                    if (tiltFactor >= 55 && tiltFactor < 70)
                    {
                        return powerFactor += 0.9;
                    }
                    if (tiltFactor >= 70 && tiltFactor < 90)
                    {
                        return powerFactor += 0.80;
                    }
                    return powerFactor;
                    
            }
            return powerFactor;
        }
    }
}
