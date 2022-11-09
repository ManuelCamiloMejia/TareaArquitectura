using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaPresentacion.Utilidades
{
    class MensajeError: Mensajes
    {
        public override string Mensaje(string TipoMensaje)
        {
            return "Trasaccion Con errores " + TipoMensaje;
        }
    }
}
