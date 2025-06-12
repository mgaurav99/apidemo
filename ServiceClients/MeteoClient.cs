
using System.Text.Json;
using System.Threading.Tasks;
using ServiceClients.Interfaces;
using ServiceClients.Models.Meteo;

namespace ServiceClients
{
    /// <summary>
    /// IMeteoClient
    /// Defines implementation to get data from meteo api
    /// </summary>
    public class MeteoClient : IMeteoClient
    {
        readonly HttpClient _httpClient;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClient"></param>
        public MeteoClient(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Provides implementation to get temperature of a city based on city name
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public async Task<string> GetTemperatureByCity(string city)
        {
            string latitude , longitude = String.Empty;
            MeteoRoot meteoRoot = new MeteoRoot();
            RootWeather rootWeather = new RootWeather();
            string temperature = String.Empty;
            string apiUrl = "https://geocoding-api.open-meteo.com/v1/search?name=" + city;
            HttpResponseMessage resp = await _httpClient.GetAsync(apiUrl);
            if(resp.IsSuccessStatusCode)
            {
                var data = await resp.Content.ReadAsStringAsync();
                meteoRoot = JsonSerializer.Deserialize<MeteoRoot>(data);
               
                latitude = meteoRoot.results[0].latitude.ToString();
                longitude = meteoRoot.results[0].longitude.ToString();
                string apiurl = "https://api.open-meteo.com/v1/forecast?latitude=" + latitude + "&longitude=" + longitude + "&current_weather=true";
                HttpResponseMessage resp2 = await _httpClient.GetAsync(apiurl);
                if (resp2.IsSuccessStatusCode)
                {
                    var data2 = await resp2.Content.ReadAsStringAsync();
                    rootWeather = JsonSerializer.Deserialize<RootWeather>(data2);
                    temperature = rootWeather.current_weather.temperature.ToString();
                    return temperature;
                }
                else
                {
                    return String.Empty;
                }
            }

            else
            {
                return String.Empty;
            }

        }
    }
}
