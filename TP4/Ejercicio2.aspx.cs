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
        private string rutaDB = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True;";

        private void CargarGridView(DataSet ds)
        {
            gv_Productos.DataSource = ds.Tables["Productos"];
            gv_Productos.DataBind();
        }

        private void CargarDataSet(DataSet ds, SqlConnection cn, string comando, string tabla)
        {
            SqlDataAdapter adapt = new SqlDataAdapter();
            
            adapt.SelectCommand = new SqlCommand(comando, cn);
            adapt.Fill(ds, tabla);
        }

        private void FiltrarComparaciones(DataSet ds, SqlConnection cn, int idProducto, int signo)
        {
            switch (signo)
            {
                case 0:
                    CargarDataSetConParametros(ds, cn, idProducto, "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos WHERE IdProducto = @IdProducto", "Productos");
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }


        }
        private void CargarDataSetConParametros(DataSet ds, SqlConnection cn, int idProducto, string comando, string tabla)
        {
            SqlCommand cmd = new SqlCommand(comando, cn);
            cmd.Parameters.AddWithValue("@IdProducto", idProducto);

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);

            adapt.Fill(ds, tabla);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = new DataSet();

                // Se establece conexion con base de datos
                SqlConnection cn = new SqlConnection(rutaDB);
                cn.Open();

                CargarDataSet(ds, cn,"SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos", "Productos");
                    
                CargarGridView(ds);

                // Se cierra la conexion
                cn.Close();
            }
        }


        protected void btn_Filtrar_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            SqlConnection cn = new SqlConnection(rutaDB);

            cn.Open();

            if(!String.IsNullOrWhiteSpace(txtBox_Producto.Text) && String.IsNullOrWhiteSpace(txtBox_Categoria.Text)) {
                int comparador = int.Parse(ddl_Producto.SelectedValue);
                int idProducto = int.Parse(txtBox_Producto.Text);

                FiltrarComparaciones(ds, cn, idProducto, comparador);

                CargarGridView(ds);
            }

            cn.Close();

            LimpiarFiltros();
            //txtBox_Producto.Text = "";
            //txtBox_Categoria.Text = "";
        }

        private void LimpiarFiltros()
        {
            txtBox_Producto.Text = "";
            txtBox_Categoria.Text = "";
            ddl_Producto.SelectedIndex = 0;
            ddl_Categoria.SelectedIndex = 0;
        }
    }
}