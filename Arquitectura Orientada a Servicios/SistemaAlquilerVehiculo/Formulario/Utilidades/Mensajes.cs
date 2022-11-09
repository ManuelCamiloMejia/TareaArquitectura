using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Utilidades
{
    class Mensajes
    {
        public string _TipoMensaje;

        public Mensajes()
        {            
        }

        public virtual string Mensaje(string TipoMensaje)
        {
            return  "Trasaccion Procesada" + TipoMensaje;
        }       

    }
    
}
