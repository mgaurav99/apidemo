using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceClients.Interfaces;
using WeatherApiService.Models;

namespace WeatherApiService.Controllers
{
    /// <summary>
    /// TemperatureServiceController
    /// Provides temperature related data
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    
    public class TemperatureServiceController : ControllerBase
    {
        readonly IMeteoClient _meteoClient;
        /// <summary>
        /// Constructor
        /// </summary>
        public TemperatureServiceController(IMeteoClient meteoClient) 
        {
            _meteoClient = meteoClient;
        }

        [Authorize]
        /// <summary>
        /// Provides city temperature value based on name of city
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("getcity")]
        public async Task<IActionResult> GetCityTemperature([FromBody] CityTemperatureRequest req)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "TemperatureData.json");

            if(!System.IO.File.Exists(filePath))
            {
                return NotFound("File TemperatureData.json not found");
            }

            try
            {
                var jsonContent =await System.IO.File.ReadAllTextAsync(filePath);
                var citiesTemperatures = JsonSerializer.Deserialize<List<CityTemperature>>(jsonContent);
                return Ok(citiesTemperatures.Find(x=>x.city.ToLower()==req.CityName.ToLower()));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, "Some error occured");
            }
        }

        /// <summary>
        /// Provides city temperature value based on name of city from meteo api
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("getcitymeteo")]
        public async Task<IActionResult> GetCityTemperatureMeteo([FromBody] CityTemperatureRequest req)
        {
            string temp = await _meteoClient.GetTemperatureByCity(req.CityName);
            if(temp=="" || temp == null)
            {
                return StatusCode(500, "Some error occured");
            }
            else
            {
                return Ok(temp);
            }
        }
    }
}
