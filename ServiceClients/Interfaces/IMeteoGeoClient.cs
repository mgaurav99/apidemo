using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceClients.Models.Meteo;

namespace ServiceClients.Interfaces
{
    /// <summary>
    /// IMeteoGeoClient
    /// Defines a contract to get data from meteo geoencoding api
    /// </summary>
    public interface IMeteoGeoClient
    {
        public Task<Coordinates> GetCoordinatesByCity(string city);
    }
}
