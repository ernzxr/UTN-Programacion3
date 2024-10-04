using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TP6_GRUPO_09.Utils
{
    public class GestionProducto
    {
        private DataTable ObtenerTabla(String Nombre, String Sql)
        {
            DataSet ds = new DataSet();
            Conexion datos = new Conexion();
            SqlDataAdapter adp = datos.ObtenerAdaptador(Sql);
            adp.Fill(ds, Nombre);
            return ds.Tables[Nombre];
        }

        public DataTable ObtenerTodosLosProductos()
        {
            return ObtenerTabla("Productos", "SELECT *FROM Productos");
        }

        private void ArmarParametrosEliminarProd(ref SqlCommand Comando, Producto producto)
        {
            SqlParameter SqlParametros = new SqlParameter
            {
                ParameterName = "@IdProducto",
                SqlDbType = SqlDbType.Int,
                Value = producto.IdProducto
            };
            Comando.Parameters.Add(SqlParametros);
        }

       
        public bool EliminarProducto(Producto prod)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosEliminarProd(ref Comando, prod);
            Conexion conexion = new Conexion();
            int filasAfectadas = conexion.EjecutarProcedimientoAlmacenado(Comando, "spEliminarProducto");
            return filasAfectadas == 1;
        }
    }

}


