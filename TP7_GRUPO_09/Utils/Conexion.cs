using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Drawing;

namespace TP7_GRUPO_09.Utils
{
    public class Conexion
    {
        private static string rutaConexion = "Data Source=localhost\\sqlexpress;Initial Catalog=BDSucursales;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection(rutaConexion);
            try
            {
                cn.Open();
                return cn;
            }
            catch
            {
                return null;
            }

        }
        public SqlDataAdapter ObtenerAdaptador(String consultaSql)
        {

            SqlConnection cn = ObtenerConexion();

            if (cn == null)
            {

                throw new Exception("No se pudo abrir la conexión a la base de datos.");
            }
            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(consultaSql, cn);
                return adaptador;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el adaptador: " + ex.Message);
            }

        }
        public int EjecutarProcedimientoAlmacenado(SqlCommand Comando, string NombreProcedimiento)
        {
            SqlConnection cn = ObtenerConexion();
            if (cn == null)
            {
                throw new Exception("No se pudo establecer conexión con la base de datos.");
            }

            try
            {
                Comando.Connection = cn;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = NombreProcedimiento;

                // Ejecutar el comando y devolver el número de filas afectadas
                int filasAfectadas = Comando.ExecuteNonQuery();
                return filasAfectadas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar el procedimiento almacenado: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }


    }
}