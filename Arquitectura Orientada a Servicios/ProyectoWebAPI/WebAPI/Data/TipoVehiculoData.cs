using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class TipoVehiculoData
    {
        public static List<TipoVehiculo> ListarTipoVehiculo()
        {
            List<TipoVehiculo> lista = new List<TipoVehiculo>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                try
                {
                    string query = "SELECT idtipo, tipo fROM TipoVehiculo";
                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);

                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new TipoVehiculo()
                            {
                                idtipo = Convert.ToInt32(dr["idtipo"]),
                                tipo = Convert.ToString(dr["tipo"]),
                            }); ;
                        }
                    }

                }
                catch (Exception ex)
                {
                    lista = new List<TipoVehiculo>();
                }

                return lista;

            }
        }
    }
}