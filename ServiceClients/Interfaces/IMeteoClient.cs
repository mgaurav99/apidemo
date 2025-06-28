using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceClients.Models.Meteo;

namespace ServiceClients.Interfaces
{
    /// <summary>
    /// IMeteoClient
    /// Defines a contract to get data from meteo api
    /// </summary>
    public interface IMeteoClient
    {
        public Task<Coordinates>GetCoordinatesByCity(string city);
        public Task<string> GetTemperatureByCoordinates(Coordinates cordinates);
    }
}
