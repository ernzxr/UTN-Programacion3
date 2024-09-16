using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace TP4
{
    public partial class Ejercicio2 : System.Web.UI.Page
    {
        private string rutaDB = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                DataSet ds = new DataSet();

                // Se establece conexion con base de datos
                SqlConnection cn = new SqlConnection(rutaDB);
                cn.Open();

                CargarDataSet(ds, cn,
                    "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad " +
                    "FROM Productos",
                    "Productos");

                CargarGridView(ds);

                // Se cierra la conexion
                cn.Close();
            }
        }

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

        private void FiltrarProductos(DataSet ds, SqlConnection cn, int idProducto, int signo)
        {
            string filtro = "";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.Parameters.AddWithValue("@IdProducto", idProducto);
            switch (signo)
            {
                case 0:
                    // Igual 
                    filtro = "=";
                    break;
                case 1:
                    // Mayor
                    filtro = ">";
                    break;
                case 2:
                    // Menor
                    filtro = "<";
                    break;
            }
            cmd.CommandText = "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad " +
                $"FROM Productos WHERE IdProducto {filtro} @IdProducto";
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            adapt.Fill(ds, "Productos");
        }

        private void FiltrarCategorias(DataSet ds, SqlConnection cn, int idCategoria, int signo)
        {
            string filtro = "";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
            switch (signo)
            {
                case 0:
                    // Igual 
                    filtro = "=";
                    break;
                case 1:
                    // Mayor
                    filtro = ">";
                    break;
                case 2:
                    // Menor
                    filtro = "<";
                    break;
            }
            cmd.CommandText = "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad " +
                $"FROM Productos WHERE IdCategoría {filtro} @IdCategoria " +
                $"ORDER BY IdCategoría";
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            adapt.Fill(ds, "Productos");
        }

        private void CargarTodo()
        {
            SqlConnection cn = new SqlConnection(rutaDB);
            cn.Open();

            string consulta = "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos";

            SqlDataAdapter adapt = new SqlDataAdapter(consulta, cn);

            DataSet ds = new DataSet();
            adapt.Fill(ds, "Productos");

            gv_Productos.DataSource = ds.Tables["Productos"];
            gv_Productos.DataBind();
        }

        private void FiltrarXProductosYCategorias(DataSet ds, SqlConnection cn, int idProducto, int idCategoria, int tipoFiltroProducto, int tipoFiltroCategoria)
        {
            string filtroPro = "", filtroCat = "";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.Parameters.AddWithValue("@IdProducto", idProducto);
            cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);

            switch (tipoFiltroProducto)
            {
                case 0:
                    // Igual 
                    filtroPro = "=";
                    break;
                case 1:
                    // Mayor
                    filtroPro = ">";
                    break;
                case 2:
                    // Menor
                    filtroPro = "<";
                    break;
            }

            switch (tipoFiltroCategoria)
            {
                case 0:
                    // Igual 
                    filtroCat = "=";
                    break;
                case 1:
                    // Mayor
                    filtroCat = ">";
                    break;
                case 2:
                    // Menor
                    filtroCat = "<";
                    break;
            }

            cmd.CommandText = "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad " +
                $"FROM Productos WHERE IdProducto {filtroPro} @IdProducto AND IdCategoría {filtroCat} @IdCategoria " +
                $"ORDER BY IdCategoría";

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            adapt.Fill(ds, "Productos");
        }

        protected void btn_Filtrar_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection(rutaDB);
            bool filtroPro = String.IsNullOrWhiteSpace(txtBox_Producto.Text);
            bool filtroCat = String.IsNullOrWhiteSpace(txtBox_Categoria.Text);

            cn.Open();

            if (!filtroPro && filtroCat)
            {
                // Solo se filtra por producto
                int tipoFiltro = int.Parse(ddl_Producto.SelectedValue);
                int idProducto = int.Parse(txtBox_Producto.Text);

                FiltrarProductos(ds, cn, idProducto, tipoFiltro);
            }
            else if (filtroPro && !filtroCat)
            {
                // Solo se filtra por categoria
                int tipoFiltro = int.Parse(ddl_Categoria.SelectedValue);
                int idCategoria = int.Parse(txtBox_Categoria.Text);

                FiltrarCategorias(ds, cn, idCategoria, tipoFiltro);
            }
            else if (!filtroPro && !filtroCat)
            {
                // Se seleccionan ambos filtros
                int tipoFiltroProducto = int.Parse(ddl_Producto.SelectedValue);
                int idProducto = int.Parse(txtBox_Producto.Text);

                int tipoFiltroCategoria = int.Parse(ddl_Categoria.SelectedValue);
                int idCategoria = int.Parse(txtBox_Categoria.Text);

                // Aplicar varios filtros
                FiltrarXProductosYCategorias(ds, cn, idProducto, idCategoria, tipoFiltroProducto, tipoFiltroCategoria);
            }
            else
            {
                // Carga el gridview completo sin filtros
                CargarDataSet(ds, cn,
                    "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad " +
                    "FROM Productos",
                    "Productos");
            }

            cn.Close();

            CargarGridView(ds);
            LimpiarFiltros();
        }

        private void LimpiarFiltros()
        {
            txtBox_Producto.Text = "";
            txtBox_Categoria.Text = "";
            ddl_Producto.SelectedIndex = 0;
            ddl_Categoria.SelectedIndex = 0;
        }

        protected void btn_QuitarF_Click(object sender, EventArgs e)
        {
            // Carga el gridview completo sin filtros
            CargarTodo();
            LimpiarFiltros();
        }
    }
}