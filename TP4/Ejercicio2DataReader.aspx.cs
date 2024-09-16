using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4
{
    public partial class Ejercicio2DataReader : System.Web.UI.Page
    {
        string rutaNeptunoSQL = @"Data Source=localhost\sqlexpress;Initial Catalog=Neptuno;Integrated Security=True";

        private void CargarTodo() //Carga todos los datos de la tabla Productos
        {
            SqlConnection cn = new SqlConnection(rutaNeptunoSQL);
            cn.Open();

            SqlCommand cmdProductos = new SqlCommand("SELECT IdProducto, NombreProducto, IdCategoría, " +
                                                     "CantidadPorUnidad, PrecioUnidad FROM PRODUCTOS", cn);

            SqlDataReader dr = cmdProductos.ExecuteReader();

            CargarGridView(dr);


            cn.Close();

            return;
        }

        private void CargarGridView(SqlDataReader dr)
        {
            gv_Productos.DataSource = dr;
            gv_Productos.DataBind();
        }

        private String ObtenerConsulta(SqlCommand cmd, int id, int valorDDL)
        {
            string consulta = "";

            switch (valorDDL)
            {
                case 1: //idProducto = valor del txtBox_Producto
                    cmd.Parameters.AddWithValue("@IdProducto", id);
                    consulta = "IdProducto = @IdProducto";
                    break;
                case 2: //idProducto > valor del txtBox_Producto
                    cmd.Parameters.AddWithValue("@IdProducto", id);
                    consulta = "IdProducto > @IdProducto";
                    break;
                case 3: //idProducto < valor del txtBox_Producto
                    cmd.Parameters.AddWithValue("@IdProducto", id);
                    consulta = "IdProducto < @IdProducto";
                    break;
                case 4: //idCategoria = valor del txtBox_Categoria
                    cmd.Parameters.AddWithValue("@IdCategoria", id);
                    consulta = "IdCategoría = @IdCategoria";
                    break;
                case 5: //idCategoria > valor del txtBox_Categoria
                    cmd.Parameters.AddWithValue("@IdCategoria", id);
                    consulta = "IdCategoría > @IdCategoria";
                    break;
                case 6: //idCategoria < valor del txtBox_Categoria
                    cmd.Parameters.AddWithValue("@IdCategoria", id);
                    consulta = "IdCategoría < @IdCategoria";
                    break;
            }

            return consulta;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if(IsPostBack == false)
            {
                CargarTodo();
            }
        }

        protected void btn_Filtrar_Click(object sender, EventArgs e)
        {
            //Establezco la cadena de conexión, para luego abrirla
            SqlConnection cn = new SqlConnection(rutaNeptunoSQL);

            cn.Open();

            //Consulto si los TextBoxs no están vacios y los guardo dentro de una variable booleana
            bool tieneIdProducto = !String.IsNullOrWhiteSpace(txtBox_Producto.Text);
            bool tieneIdCategoria = !String.IsNullOrWhiteSpace(txtBox_Categoria.Text);


            //Casteo los valores de los DropDownLists
            int valorDDLProducto = int.Parse(ddl_Producto.SelectedValue);
            int valorDDLCategoria = int.Parse(ddl_Categoria.SelectedValue);

            //Si el usuario ingresó algo en alguno de los TextBoxs, convierto el texto a entero
            //y los almaceno dentro de las variables idProducto o idCategoria
            int idProducto = 0;
            int idCategoria = 0;
            if (tieneIdProducto)
            {
                idProducto = int.Parse(txtBox_Producto.Text);
            }
            if (tieneIdCategoria)
            {
                idCategoria = int.Parse(txtBox_Categoria.Text);
            }

            //Genero la primera parte de la consulta
            string consulta = "SELECT IdProducto, NombreProducto, IdCategoría, " +
                              "CantidadPorUnidad, PrecioUnidad FROM PRODUCTOS";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;

            //Si cargó txtBox_Producto pero no txtBox_Categoria...
            if (tieneIdProducto && !tieneIdCategoria)
            {
                consulta += " WHERE " + ObtenerConsulta(cmd, idProducto, valorDDLProducto);
                cmd.CommandText = consulta;
            }

            //Si cargó txtBox_Categoria pero no txtBox_Producto...
            if (tieneIdCategoria && !tieneIdProducto)
            {
                consulta += " WHERE " + ObtenerConsulta(cmd, idCategoria, valorDDLCategoria);
                cmd.CommandText = consulta;
            }

            //Si cargó ambos campos...
            if (tieneIdProducto && tieneIdCategoria)
            {
                consulta += " WHERE " + ObtenerConsulta(cmd, idProducto, valorDDLProducto) + " AND " + ObtenerConsulta(cmd, idCategoria, valorDDLCategoria);
                cmd.CommandText = consulta;
            }

            //Si no cargó nada...
            if (!tieneIdProducto && !tieneIdCategoria)
            {
                cmd.CommandText = consulta;
            }

            SqlDataReader dr = cmd.ExecuteReader();
            CargarGridView(dr);


            cn.Close();

            txtBox_Categoria.Text = "";
            txtBox_Producto.Text = "";
        }

        protected void btn_QuitarFiltro_Click(object sender, EventArgs e)
        {
            CargarTodo();
            txtBox_Categoria.Text = "";
            txtBox_Producto.Text = "";
        }
    }
}