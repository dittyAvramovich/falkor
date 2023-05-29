using FalkorTest.Classes;
using Microsoft.AspNetCore.Mvc;
using static serverFalkor.Classes.Department;
using static serverFalkor.Classes.Floor;
using static serverFalkor.Classes.Table;

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
        public List<floor> GetFloors()
        {
            return Hospital.GetFloors();
        }


        [HttpGet("{floorId}")]
        public List<departments> GetDepartmentsByFloor(int floorId)
        {
            return Hospital.GetDepartmentsByFloor(floorId);
        }

        [HttpGet("{floorId}/{departmentId}")]
        public List<table> GetTable(int floorId, int departmentId)
        {
            return Hospital.GetTable(floorId, departmentId);
        }
    }
}