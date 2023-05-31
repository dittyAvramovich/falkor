using FalkorTest.Classes;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static serverFalkor.Classes.Department;
using static serverFalkor.Classes.Floor;

namespace serverFalkor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       

       
        [HttpGet(Name = "GetWeatherForecastControllert")]
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
        public DataTable GetTable(int floorId, int departmentId)
        {
            return Hospital.GetTable1(floorId, departmentId);
        }
    }
}