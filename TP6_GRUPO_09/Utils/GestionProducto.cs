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
        public GestionProducto() { }

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



    }
}