using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceClients.Interfaces;
using ServiceClients.Models.Meteo;
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
        [Obsolete]
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
        /// Provides city coordinates value based on name of city from meteo api
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("getcoordinate")]
        public async Task<IActionResult> GetCoordinatesByCity([FromBody] CityTemperatureRequest req)
        {
            if (string.IsNullOrWhiteSpace(req?.CityName))
            {
                return BadRequest("City name is required.");
            }
            var  coordinates = await _meteoClient.GetCoordinatesByCity(req.CityName);
            if (string.IsNullOrWhiteSpace(coordinates?.latitude) || string.IsNullOrWhiteSpace(coordinates?.longitude))
            {
                return StatusCode(502, "Failed to fetch coordinates from external service.");
            }
           
            else
            {
                return Ok(coordinates);
            }
        }

        /// <summary>
        /// Provides temperature of city using coordinates of that city
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        [HttpPost("gettemperature")]
        public async Task<IActionResult>GetCityTemperatureByCoordinates([FromBody] Coordinates coordinates)
        {
            if(string.IsNullOrEmpty(coordinates?.latitude) || string.IsNullOrEmpty(coordinates?.longitude))
            {
                return BadRequest("Longitude and latitude are required.");
            }

            string temperature = await _meteoClient.GetTemperatureByCoordinates(coordinates);
            if(string.IsNullOrEmpty(temperature))
            {
                return StatusCode(502, "Failed to fetch temperature from external service");
            }
            else
            {
                return Ok(temperature);
            }
        }
    }
}
