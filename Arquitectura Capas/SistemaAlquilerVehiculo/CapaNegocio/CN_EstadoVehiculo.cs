using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
   public class CN_EstadoVehiculo
    {
        private CD_EstadosVehiculos objcd_estadovehi = new CD_EstadosVehiculos();

        public List<EstadoVehiculo> Listar()
        {
            return objcd_estadovehi.Listar();
        }
    }
}
