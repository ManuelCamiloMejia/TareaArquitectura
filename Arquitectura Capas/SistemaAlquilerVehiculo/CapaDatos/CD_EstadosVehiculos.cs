using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_EstadosVehiculos
    {
        public List<EstadoVehiculo> Listar()
        {
            List<EstadoVehiculo> lista = new List<EstadoVehiculo>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT idestado, nombre fROM EstadosVehiculo";
                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);

                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new EstadoVehiculo()
                            {
                                idEstado = Convert.ToInt32(dr["idestado"]),
                                nombre = Convert.ToString(dr["nombre"]),
                            }); ;
                        }
                    }

                }
                catch (Exception ex)
                {
                    lista = new List<EstadoVehiculo>();
                }

                return lista;

            }
        }
    }
}
