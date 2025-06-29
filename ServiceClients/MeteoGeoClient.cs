using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ServiceClients.Interfaces;
using ServiceClients.Models.Meteo;

namespace ServiceClients
{
    /// <summary>
    /// MeteoGeoClient
    /// Defines implementation to get data from meteo geo api
    /// </summary>
    public class MeteoGeoClient : IMeteoGeoClient
    {
        readonly HttpClient _httpClient;

        private readonly IJsonSerializer _jsonSerializer;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="jsonSerializer"></param>
        public MeteoGeoClient(HttpClient httpClient, IJsonSerializer jsonSerializer)
        {
            _httpClient = httpClient;
            _jsonSerializer = jsonSerializer;
        }

        /// <summary>
        /// Get coordinates of a city using city name.
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public async Task<Coordinates> GetCoordinatesByCity(string city)
        {
            try
            {
                MeteoRoot meteoRoot = null;
                string apiUrl = $"/v1/search?name={city}";
                HttpResponseMessage resp = await _httpClient.GetAsync(apiUrl);
                resp.EnsureSuccessStatusCode();

                var data = await resp.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(data))
                {
                    meteoRoot = _jsonSerializer.Deserialize<MeteoRoot>(data);
                    return meteoRoot.ToCoordinates();

                }
                else
                {
                    return new Coordinates();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            return new Coordinates();
        }
    }
}

