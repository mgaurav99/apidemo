using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherApiService.Services;
using WeatherApiService.Utilities;

namespace WeatherApiService.Controllers
{
    /// <summary>
    /// Authcontroller
    /// Performs various authentication related functions
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _jwtTokenService;

        /// <summary>
        /// Constructor
        /// Injecting services needed.
        /// </summary>
        /// <param name="jwtTokenService"></param>
        public AuthController(JwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        /// <summary>
        /// Returns jwt token for valid users
        /// </summary>
        /// <param name="user"></param>
        /// <returns>IActionResult</returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            // In a real application, validate the user credentials from a database
            if (user.Username == "gaurav" && user.Password == "May@2025")
            {
                var token = _jwtTokenService.GenerateToken(user.Username);
                return Ok(token);
            }

            return Unauthorized();
        }
    }
}
