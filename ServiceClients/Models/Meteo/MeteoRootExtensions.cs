using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClients.Models.Meteo
{
    /// <summary>
    /// MeteoRootExtensions
    /// Contains extension methods for MeteoRoot class
    /// </summary>
    public static class MeteoRootExtensions
    {
        /// <summary>
        /// Returns coordinates from MeteoRoot object
        /// </summary>
        /// <param name="meteoRoot"></param>
        /// <returns></returns>
        public static Coordinates ToCoordinates(this MeteoRoot meteoRoot)
        {
            if (meteoRoot?.Results == null || !meteoRoot.Results.Any())
                return new Coordinates();

            var firstResult = meteoRoot.Results[0];
            return new Coordinates
            {
                latitude = firstResult.latitude.ToString(),
                longitude = firstResult.longitude.ToString()
            };
        }
    }

}
