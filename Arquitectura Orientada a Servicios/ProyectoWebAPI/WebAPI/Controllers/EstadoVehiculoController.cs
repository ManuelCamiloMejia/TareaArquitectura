using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{

    [Route("api/EstadoVehiculo")]
    public class EstadoVehiculoController : ApiController
    {
        [HttpGet]
        public List<EstadoVehiculo> Get()
        {
            return EstadoVehiculoData.Listar();
        }
    }
}