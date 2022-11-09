using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Vehiculos
    {
        private CD_Vehiculos objcd_Vehiculos= new CD_Vehiculos();

        public List<vehiculos> ListarVehiculos()
        {
            return objcd_Vehiculos.ListarVehiculos();
        }

              public int Registrar(vehiculos obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.matricula == "")
            {
                mensaje += "Es necesario la matricula del vehiculo\n";
            }

            if (obj.marca == "")
            {
                mensaje += "Es necesaria la marca\n";
            }

            if (obj.modelo == "")
            {
                mensaje += "Es necesario el modelo del vehiculo\n";
            }
                      

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Vehiculos.RegistrarVehiculo(obj, out mensaje);
            }
        }

        public bool Eliminar(vehiculos obj, out string mensaje)
        {
            return objcd_Vehiculos.Eliminar(obj, out mensaje);
        }

        
        public bool Editar(vehiculos obj, out string mensaje)
        {

            mensaje = string.Empty;

            if (obj.matricula == "")
            {
                mensaje += "Es necesario la matricula del vehiculo\n";
            }

            if (obj.marca == "")
            {
                mensaje += "Es necesaria la marca\n";
            }

            if (obj.modelo == "")
            {
                mensaje += "Es necesario el modelo del vehiculo\n";
            }


            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Vehiculos.EditarVehiculo(obj, out mensaje);
            }

        }
    }
}
