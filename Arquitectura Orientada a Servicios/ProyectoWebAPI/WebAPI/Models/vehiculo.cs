using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class vehiculo
    {
        public int idVehiculo { get; set; }
        public string matricula { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public TipoVehiculo oTipoVehiculo { get; set; }
        public EstadoVehiculo obEstadoVehiculo { get; set; }
        public int PesoToneladas { get; set; }
    }
}