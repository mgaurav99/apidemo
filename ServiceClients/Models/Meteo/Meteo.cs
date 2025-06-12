namespace ServiceClients.Models.Meteo
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class MeteoResult
    {
        public int id { get; set; }
        public string name { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double elevation { get; set; }
        public string feature_code { get; set; }
        public string country_code { get; set; }
        public int admin1_id { get; set; }
        public string timezone { get; set; }
        public int population { get; set; }
        public int country_id { get; set; }
        public string country { get; set; }
        public string admin1 { get; set; }
        public int? admin2_id { get; set; }
        public int? admin3_id { get; set; }
        public List<string> postcodes { get; set; }
        public string admin2 { get; set; }
        public string admin3 { get; set; }
    }

    public class MeteoRoot
    {
        public List<MeteoResult> results { get; set; }
        public double generationtime_ms { get; set; }
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class CurrentWeather
    {
        public string time { get; set; }
        public int interval { get; set; }
        public double temperature { get; set; }
        public double windspeed { get; set; }
        public int winddirection { get; set; }
        public int is_day { get; set; }
        public int weathercode { get; set; }
    }

    public class CurrentWeatherUnits
    {
        public string time { get; set; }
        public string interval { get; set; }
        public string temperature { get; set; }
        public string windspeed { get; set; }
        public string winddirection { get; set; }
        public string is_day { get; set; }
        public string weathercode { get; set; }
    }

    public class RootWeather
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double generationtime_ms { get; set; }
        public int utc_offset_seconds { get; set; }
        public string timezone { get; set; }
        public string timezone_abbreviation { get; set; }
        public double elevation { get; set; }
        public CurrentWeatherUnits current_weather_units { get; set; }
        public CurrentWeather current_weather { get; set; }
    }




}
