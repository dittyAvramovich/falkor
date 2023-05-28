using FalkorTest.Classes;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace FalkorTest
{
    [RoutePrefix("api")]
   
    public class HomeController : ApiController
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [Microsoft.AspNetCore.Mvc.HttpGet()]
        [System.Web.Http.Route("getFloors")]
        public List<string> GetFloors()
        {
             //return new List<string>();

            return Hospital.GetFloors1();

        }

    }
}






