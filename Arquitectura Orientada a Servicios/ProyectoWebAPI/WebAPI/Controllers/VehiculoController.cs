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
    
    public class VehiculoController : ApiController
    {
       //GET api/<controller>
       [HttpGet]
       public List<vehiculo> Get()
        {
            return VehiculoData.ListarVehiculos();
        }

        //DELETE  api/<controller>/1
        [HttpDelete]
        public bool Delete(int id)
        {
            return VehiculoData.Eliminar(id);
        }

        // PUT  api/<controller>
        [HttpPut]
        public bool Put([FromBody] vehiculo oVehiculo)
        {
            return VehiculoData.EditarVehiculo(oVehiculo, out string mensaje);
        }

        // POST  api/<controller>
        [HttpPost]
        public int Post([FromBody] vehiculo oVehiculo)
        {
            return VehiculoData.Registrar(oVehiculo);
        }

    }
}