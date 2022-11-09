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

    [Route("api/TipoVehiculo")]
    public class TipoVehiculoController : ApiController
    {
      [HttpGet]
        public List<TipoVehiculo> Get()
        {
            return TipoVehiculoData.ListarTipoVehiculo();
        }
    }
}