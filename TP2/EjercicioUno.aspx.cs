using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP2
{
    public partial class EjercicioUno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTabla_Click(object sender, EventArgs e)
        {
            string Producto1 = txtProducto1.Text;
            string Producto2 = txtProducto2.Text;
            int Cantidad1 = 0;
            int Cantidad2 = 0;

            if (string.IsNullOrWhiteSpace(Producto1) || string.IsNullOrWhiteSpace(Producto2))
            {
                lblErrorDescripcion.Text = "Atención debe agregar descripción del producto";
                lblErrorDescripcion.Visible = true; ;
                return;
            }
            else
            {
                lblErrorDescripcion.Text = string.Empty;
                lblErrorDescripcion.Visible = false;
            }

            if ((!int.TryParse(txtCantidad1.Text, out Cantidad1) || Cantidad1 < 0) || (!int.TryParse(txtCantidad2.Text, out Cantidad2) || Cantidad2 < 0))
            {
                lblError.Text = "Atención: Debe ingresar cantidad entera positivo o cero";
                lblError.Visible = true;
                return;
            }
            else
            {
                lblError.Text = string.Empty;
                lblError.Visible = false;
            }


            int Total = Cantidad1 + Cantidad2;

            String tabla = "<table border = '1'> ";
            tabla += "<tr><th>Producto</th><th>Cantidad</th></tr>";

            tabla += "<tr>";
            tabla += "<td>" + Producto1 + "</td><td>" + Cantidad1.ToString() + "</td>";
            tabla += "</tr>";

            tabla += "<tr>";
            tabla += "<td>" + Producto2 + "</td><td>" + Cantidad2.ToString() + "</td>";
            tabla += "</tr>";

            tabla += "<tr>";
            tabla += "<td>TOTAL</td><td>" + Total.ToString() + "</td>";
            tabla += "</tr>";

            tabla += "</table>";


            lblTabla.Text = tabla;
            txtProducto1.Text = string.Empty;
            txtProducto2.Text = string.Empty;
            txtCantidad1.Text = string.Empty;
            txtCantidad2.Text = string.Empty;


        }
    }

}

