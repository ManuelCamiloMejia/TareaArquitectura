//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Alquiler
{
    using System;
    using System.Collections.Generic;
    
    public partial class Alquileres
    {
        public int idAlquiler { get; set; }
        public Nullable<int> idUsuario { get; set; }
        public Nullable<int> idVehiculo { get; set; }
        public Nullable<decimal> precioAlquiler { get; set; }
        public Nullable<bool> idEstado { get; set; }
        public Nullable<int> numeroDias { get; set; }
    
        public virtual vehiculos vehiculos { get; set; }
    }
}
