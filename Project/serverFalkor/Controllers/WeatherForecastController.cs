using FalkorTest.Classes;
using Microsoft.AspNetCore.Mvc;

namespace serverFalkor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public List<string> GetFloors()
        {
            return Hospital.GetFloors1();
        }


        [HttpGet("{floorId}")]
        public List<string> GetDepartmentsByFloor(int floorId)
        {
            return Hospital.GetDepartmentsByFloor(floorId);
        }

        [HttpGet("{floorId}/{departmentId}")]
        public List<string> GetTable(int floorId, int departmentId)
        {
            return Hospital.GetTable(floorId, departmentId);
        }
    }
}