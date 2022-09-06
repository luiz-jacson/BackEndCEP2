using Microsoft.AspNetCore.Mvc;

namespace Projeto_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
    
        [HttpGet(Name = "GetWeatherForecast")]
        public int Get()
        {
            return 123;
            
        }
    }
}