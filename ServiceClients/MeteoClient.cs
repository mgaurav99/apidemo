
using System.Text.Json;
using System.Threading.Tasks;
using ServiceClients.Interfaces;
using ServiceClients.Models.Meteo;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ServiceClients
{
    /// <summary>
    /// MeteoClient
    /// Defines implementation to get data from meteo api
    /// </summary>
    public class MeteoClient : IMeteoClient 
    {
        readonly HttpClient _httpClient;

        private readonly IJsonSerializer _jsonSerializer;

     /// <summary>
     /// Constructor
     /// </summary>
     /// <param name="httpClient"></param>
     /// <param name="jsonSerializer"></param>
        public MeteoClient(HttpClient httpClient, IJsonSerializer jsonSerializer)
        {
            _httpClient = httpClient;
            _jsonSerializer = jsonSerializer;
        }

        /// <summary>
        /// Get temperature of a city using coordinates.
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        public async Task<string> GetTemperatureByCoordinates(Coordinates coordinates)
        {
            string temperature = string.Empty;

            if (coordinates != null)
            {
                string apiurl = $"/v1/forecast?latitude={coordinates.latitude}&longitude=" +
                    $"{coordinates.longitude}&current_weather=true";
                HttpResponseMessage resp2 = await _httpClient.GetAsync(apiurl);
                if (resp2.IsSuccessStatusCode)
                {
                    var data2 = await resp2.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(data2))
                    {
                        var rootWeather = _jsonSerializer.Deserialize<RootWeather>(data2);
                        temperature = rootWeather.ToTemperature();
                        return temperature;
                    }
                    else
                    {
                        return string.Empty;
                    }

                }
                else
                {
                    return string.Empty;
                }

            }
            else
            {
                return string.Empty;
            }

        }


    }
}
