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
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        string rutaNeptunoSQL = @"Data Source=localhost\sqlexpress;Initial Catalog=Neptuno;Integrated Security=True";



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
                    
                    break;
                case 3: //idProducto < valor del txtBox_Producto
                    
                    break;
                case 4: //idCategoria = valor del txtBox_Categoria
                    
                    break;
                case 5: //idCategoria > valor del txtBox_Categoria
                    
                    break;
                case 6: //idCategoria < valor del txtBox_Categoria
                    
                    break;
            }
            return consulta;
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
                string cs1 = ObtenerConsulta(cmd, idProducto, valorDDLProducto);

                consulta += " WHERE " + cs1;
                cmd.CommandText = consulta;
            }

            //Continuar preguntando...

            SqlDataReader dr = cmd.ExecuteReader();
            CargarGridView(dr);


            cn.Close();

            txtBox_Categoria.Text = "";
            txtBox_Producto.Text = "";
        }
    }
}