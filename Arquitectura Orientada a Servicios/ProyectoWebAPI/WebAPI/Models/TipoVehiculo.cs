using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class TipoVehiculo
    {
        public int idtipo { get; set; }
        public string tipo { get; set; }
        public decimal precioAlquiler { get; set; }
    }
}