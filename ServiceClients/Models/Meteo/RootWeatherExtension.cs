using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClients.Models.Meteo
{
    /// <summary>
    /// RootWeatherExtension
    ///Contains extension method for RootWeather class
    /// </summary>
    public static class RootWeatherExtension
    {
        /// <summary>
        /// Returns temperature as string from RootWether object
        /// </summary>
        /// <param name="rootWeather"></param>
        /// <returns></returns>
        public static string ToTemperature(this RootWeather rootWeather)
        {
            if(rootWeather?.current_weather == null)
            {
                return string.Empty;
            }
            else
            {
                return rootWeather.current_weather.temperature.ToString();
            }
        }
    }
}
