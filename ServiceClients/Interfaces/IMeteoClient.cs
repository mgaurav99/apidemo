using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClients.Interfaces
{
    /// <summary>
    /// IMeteoClient
    /// Defines a contract to get data from meteo api
    /// </summary>
    public interface IMeteoClient
    {
        /// <summary>
        /// Get temperature of a city based on city name
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public Task<string> GetTemperatureByCity(string city);
    }
}
