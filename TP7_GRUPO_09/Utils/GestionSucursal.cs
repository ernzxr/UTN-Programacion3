using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TP7_GRUPO_09.Utils
{
    public class GestionSucursal
    {
        private DataTable ObtenerTabla(String Nombre, String Sql)
        {
            DataSet ds = new DataSet();
            Conexion datos = new Conexion();
            SqlDataAdapter adp = datos.ObtenerAdaptador(Sql);
            adp.Fill(ds, Nombre);
            return ds.Tables[Nombre];
        }

        public DataTable ObtenerSucursales()
        {
            return ObtenerTabla("Sucursales", "SELECT * FROM Sucursal");
        }

        public DataTable ObtenerSucursalesPorNombre(String nombreSucursal)
        {
            return ObtenerTabla("Sucursal", "SELECT * FROM Sucursal WHERE NombreSucursal LIKE '%" + nombreSucursal + "%'");
        }

        public DataTable ObtenerSucursalesPorProvincia(int provinciaID)
        {
            string query = "SELECT * FROM Sucursal WHERE Id_ProvinciaSucursal = @ProvinciaID";
            DataSet ds = new DataSet();
            Conexion datos = new Conexion();

            try
            {
                SqlDataAdapter adp = datos.ObtenerAdaptador(query);
                adp.SelectCommand.Parameters.AddWithValue("@ProvinciaID", provinciaID);
                adp.Fill(ds, "Sucursal");
            }
            catch (Exception ex)
            { 
                throw new Exception("Error al obtener sucursales por provincia", ex);
            }
            return ds.Tables["Sucursal"];
        }

    }
}


