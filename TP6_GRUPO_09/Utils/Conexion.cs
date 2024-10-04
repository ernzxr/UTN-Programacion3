using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TP6_GRUPO_09.Utils
{
    public class Conexion
    {
        private static string rutaConexion = "Data Source=localhost\\sqlexpress; Initial Catalog=Neptuno; Integrated Security=True";

        public SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection(rutaConexion);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
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
    }
}