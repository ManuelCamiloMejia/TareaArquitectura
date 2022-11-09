using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_TipoVehiculos
    {
        private CD_TipoVehiculo objcd_tipovehiculo = new CD_TipoVehiculo();

        public List<TipoVehiculo> ListarTipoVehiculo()
        {
            return objcd_tipovehiculo.ListarTipoVehiculo();
        }

    }
}
