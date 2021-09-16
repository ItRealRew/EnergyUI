using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EnergyUI.DAO;
using System.Text.Json;
using System.Collections.Generic;
using System;
using Nancy.Json;

namespace EnergyUI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EnergyController : ControllerBase
    {
        EnergyApi energyApi = new EnergyApi();

        //[HttpPost]
        //public ActionResult Get()
        //{
         //   DateTime dt = new DateTime();
         //   JavaScriptSerializer serializer = new JavaScriptSerializer();
         //   return serializer.Serialize(energyApi.GetMeasurings(1, dt));
        //}
    }
}
