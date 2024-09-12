using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4
{
    public partial class Ejercicio2 : System.Web.UI.Page
    {
        void CargarGridView(DataSet ds)
        {
            gv_Productos.DataSource = ds.Tables["Productos"];
            gv_Productos.DataBind();

        }

        void CargarDataSet(DataSet ds, SqlConnection cn)
        {
            SqlDataAdapter adapt = new SqlDataAdapter();

            // Consultar y cargar la tabla Provincias
            adapt.SelectCommand = new SqlCommand("SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos", cn);
            adapt.Fill(ds, "Productos");

            // Consultar y cargar la tabla Localidades
            // Se puede utilizar SelectCommand.CommandText para cambiar la consulta
            // ...
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string rutaDB = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True;";

            if (!IsPostBack)
            {
                DataSet ds = new DataSet();

                // Se establece conexion con base de datos
                SqlConnection cn = new SqlConnection(rutaDB);
                cn.Open();

                CargarDataSet(ds, cn);
                    
                CargarGridView(ds);

                // Se cierra la conexion
                cn.Close();
            }
        }
    }
}