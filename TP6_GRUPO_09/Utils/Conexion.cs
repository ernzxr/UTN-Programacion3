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
        private static string rutaConexion = "Data Source=localhost;Initial Catalog=Neptuno;Integrated Security=True";

        public Conexion() { }


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
    /*
    public DataTable ObtenerTablas(string consultaSQL, string nombreTabla)
        {
            cn.Open();
            SqlDataAdapter adap = new SqlDataAdapter(consultaSQL, cn);
            DataSet ds = new DataSet();
            adap.Fill(ds, nombreTabla);
            cn.Close();
            return ds.Tables[nombreTabla];
        }

        public int EjecutarConsulta(string consultaSQL)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand(consultaSQL, cn);
            int filas = (int)cmd.ExecuteNonQuery();
            cn.Close();
            return filas;
        }
    }*/
}