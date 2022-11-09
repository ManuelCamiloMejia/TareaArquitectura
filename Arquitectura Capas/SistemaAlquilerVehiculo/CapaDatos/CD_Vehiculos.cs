using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
   public class CD_Vehiculos
    {
        public List<vehiculos> ListarVehiculos()
        {


            List<vehiculos> lista = new List<vehiculos>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select idVehiculo, matricula, marca,modelo,IdTipoVehiculo, tv.tipo, ee.nombre as Estado, ee.IdEstado, isnull(PesoToneladas,0) as PesoToneladas from vehiculos V");
                    query.AppendLine("INNER JOIN tipoVehiculo tv on v.idTipoVehiculo=tv.idtipo");
                    query.AppendLine("INNER JOIN EstadosVehiculo ee on v.idEstado=ee.IdEstado");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new vehiculos()
                            {
                                idVehiculo = Convert.ToInt32(dr["idVehiculo"]),
                                matricula = Convert.ToString(dr["matricula"]),
                                marca = Convert.ToString(dr["marca"]),
                                modelo = Convert.ToString(dr["modelo"]),
                                PesoToneladas = Convert.ToInt32(dr["PesoToneladas"]),
                                oTipoVehiculo = new TipoVehiculo()
                                {
                                    idtipo = Convert.ToInt32(dr["IdTipoVehiculo"]),
                                    tipo = Convert.ToString(dr["tipo"])                                    
                                },
                                obEstadoVehiculo = new EstadoVehiculo()
                                {
                                    idEstado = Convert.ToInt32(dr["IdEstado"]),
                                    nombre = Convert.ToString(dr["Estado"])
                                }
                            }); ;
                        }
                    }

                }




                catch (Exception ex)
                {
                    lista = new List<vehiculos>();
                }

                return lista;
            }


        }

        

        public int RegistrarVehiculo(vehiculos obj, out string mensaje)
        {
            int idVehiculoCreado = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARVEHICULO", oConexion);
                    cmd.Parameters.AddWithValue("Matricula", obj.matricula);
                    cmd.Parameters.AddWithValue("Marca", obj.marca);
                    cmd.Parameters.AddWithValue("Modelo", obj.modelo);
                    cmd.Parameters.AddWithValue("PesoToneladas", obj.PesoToneladas);
                    cmd.Parameters.AddWithValue("IdTipoVehiculo", obj.oTipoVehiculo.idtipo);
                    cmd.Parameters.AddWithValue("EstadoValor", obj.obEstadoVehiculo.idEstado);             

                    cmd.Parameters.Add("idVehiculoCreado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    idVehiculoCreado = Convert.ToInt32(cmd.Parameters["idVehiculoCreado"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idVehiculoCreado = 0;
                mensaje = ex.Message;
            }

            return idVehiculoCreado;
        }

        public bool EditarVehiculo(vehiculos obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EDITARVEHICULO", oConexion);
                    cmd.Parameters.AddWithValue("idVehiculo", obj.idVehiculo);
                    cmd.Parameters.AddWithValue("Matricula", obj.matricula);
                    cmd.Parameters.AddWithValue("PesoToneladas", obj.PesoToneladas);
                    cmd.Parameters.AddWithValue("Marca", obj.marca);
                    cmd.Parameters.AddWithValue("Modelo", obj.modelo);
                    cmd.Parameters.AddWithValue("IdTipoVehiculo", obj.oTipoVehiculo.idtipo);
                    cmd.Parameters.AddWithValue("EstadoValor", obj.obEstadoVehiculo.idEstado);

                    cmd.Parameters.Add("respuesta", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["respuesta"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();


                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = ex.Message;
            }

            return respuesta;
        }

        public bool Eliminar(vehiculos obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARVEHICULO", oConexion);
                    cmd.Parameters.AddWithValue("IdVehiculo", obj.idVehiculo);

                    cmd.Parameters.Add("respuesta", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["respuesta"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();


                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = ex.Message;
            }

            return respuesta;
        }

        
    }
}
