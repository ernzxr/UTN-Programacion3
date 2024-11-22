using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class AccesoDatos
    {
        private string rutaBDClinica = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=UTN2C2024PR3CLINICA;Integrated Security=True;";
        public AccesoDatos(){ }

        public SqlConnection ObtenerConexion()
        {
            try
            {
                SqlConnection cn = new SqlConnection(rutaBDClinica);
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al intentar conectar con la base de datos:");
                Console.WriteLine(ex.Message); // Aquí se imprimirá el mensaje de error específico
                throw new Exception("No se pudo establecer la conexión con la base de datos. Detalles: " + ex.Message);
            }
        }

        private SqlDataAdapter ObtenerAdaptador(String consultaSql, SqlConnection cn)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consultaSql, cn);
                return adaptador;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable ObtenerTabla(String NombreTabla, String Sql)
        {
            DataSet ds = new DataSet();
            SqlConnection Conexion = ObtenerConexion();
            SqlDataAdapter adp = ObtenerAdaptador(Sql, Conexion);
            adp.Fill(ds, NombreTabla);
            Conexion.Close();
            return ds.Tables[NombreTabla];
        }

        public DataTable ObtenerTabla(SqlCommand Comando)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(Comando);
            adp.Fill(dt);
            return dt;
        }

        public int EjecutarProcedimientoAlmacenado(SqlCommand Comando, String NombreSP)
        {
            int FilasCambiadas;
            SqlConnection Conexion = ObtenerConexion();

            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = NombreSP;
            FilasCambiadas = Comando.ExecuteNonQuery();

            Conexion.Close();
            return FilasCambiadas;
        }

        public DataTable EjecutarProcedimientoAlmacenadoLectura(SqlCommand Comando, String NombreSP)
        {
            SqlConnection Conexion = ObtenerConexion();

            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = NombreSP;

            Conexion.Close();
            return ObtenerTabla(Comando);
        }

        public int EjecutarProcedimientoAlmacenadoFuncion(SqlCommand Comando, String NombreSP)
        {
            SqlConnection Conexion = ObtenerConexion();

            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = NombreSP;

            object result = Comando.ExecuteScalar();
            return Convert.ToInt32(result);
        }

        public Boolean existe(String consulta)
        {
            Boolean estado = false;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                estado = true;
            }

            Conexion.Close();

            return estado;
        }
    }
}
