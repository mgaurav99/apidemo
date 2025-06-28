

using Newtonsoft.Json;

namespace ServiceClients.Models.Meteo
{
    public class MeteoResult
    {
        public int id { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
      
    }

    public class MeteoRoot
    {
        [JsonProperty]
        public List<MeteoResult> Results { get; set; }
    }

    public class CurrentWeather
    {
        public double temperature { get; set; }  
    }

    public class RootWeather
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public CurrentWeather current_weather { get; set; }
    }

    public class Coordinates
    {
        public string latitude { get; set; }
        public string  longitude { get; set; }
    }




}
