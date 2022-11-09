using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class VehiculoData
    {

        public static List<vehiculo> ListarVehiculos()
        {


            List<vehiculo> lista = new List<vehiculo>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
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
                            lista.Add(new vehiculo()
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
                    lista = new List<vehiculo>();
                }

                return lista;
            }


        }
        public static int Registrar(vehiculo oVehiculo)
        {
            int idVehiculoCreado = 0;
            
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARVEHICULO", oConexion);
                    cmd.Parameters.AddWithValue("Matricula", oVehiculo.matricula);
                    cmd.Parameters.AddWithValue("Marca", oVehiculo.marca);
                    cmd.Parameters.AddWithValue("Modelo", oVehiculo.modelo);
                    cmd.Parameters.AddWithValue("PesoToneladas", oVehiculo.PesoToneladas);
                    cmd.Parameters.AddWithValue("IdTipoVehiculo", oVehiculo.oTipoVehiculo.idtipo);
                    cmd.Parameters.AddWithValue("EstadoValor", oVehiculo.obEstadoVehiculo.idEstado);

                    cmd.Parameters.Add("idVehiculoCreado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    idVehiculoCreado = Convert.ToInt32(cmd.Parameters["idVehiculoCreado"].Value);                    
                }
            }
            catch (Exception ex)
            {
                idVehiculoCreado = 0;
            }

            return idVehiculoCreado;
        }

        public static bool EditarVehiculo(vehiculo obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
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

        public static bool Eliminar(int id)
        {
            bool respuesta = false;            

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARVEHICULO", oConexion);
                    cmd.Parameters.AddWithValue("IdVehiculo", id);

                    cmd.Parameters.Add("respuesta", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["respuesta"].Value);                   


                }
            }
            catch (Exception ex)
            {
                respuesta = false;                
            }

            return respuesta;
        }
    }
}