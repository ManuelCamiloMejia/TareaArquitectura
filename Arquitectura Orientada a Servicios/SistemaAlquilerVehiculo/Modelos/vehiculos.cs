using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class vehiculos
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
