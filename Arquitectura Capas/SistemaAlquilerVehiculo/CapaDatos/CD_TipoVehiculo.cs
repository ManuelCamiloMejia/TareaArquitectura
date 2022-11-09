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
    public class CD_TipoVehiculo
    {
        public List<TipoVehiculo> ListarTipoVehiculo()
        {
            List<TipoVehiculo> lista = new List<TipoVehiculo>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
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
