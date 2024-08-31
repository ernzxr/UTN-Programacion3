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
            string Producto1 = txtProducto1.Text.ToLower();
            string Producto2 = txtProducto2.Text.ToLower();
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

            

            //verificar si los productos ingresados son iguales, de ser asi generar la tabla con el producto combinado
            if (Producto1 == Producto2)
            {
                string Tabla;
                Tabla = "<table border='1'>";
                Tabla += "<tr> <td>Producto</td> <td>Cantidad</td> </tr>";
                Tabla += $"<tr> <td>{Producto1}</td> <td>{Cantidad1 + Cantidad2}</td> </tr>"; 
                Tabla += $"<tr> <td>TOTAL</td> <td>{Cantidad1 + Cantidad2}</td> </tr>"; 
                Tabla += "</table>";
                lblTabla.Text = Tabla;

            }
            else //si los productos ingresados no son iguales, generar la tabla con los productos por separado
            {
                int Total = Cantidad1 + Cantidad2;

                String Tabla = "<table border = '1'> ";
                Tabla += "<tr><th>Producto</th><th>Cantidad</th></tr>";

                Tabla += "<tr>";
                Tabla += "<td>" + Producto1 + "</td><td>" + Cantidad1.ToString() + "</td>";
                Tabla += "</tr>";

                Tabla += "<tr>";
                Tabla += "<td>" + Producto2 + "</td><td>" + Cantidad2.ToString() + "</td>";
                Tabla += "</tr>";

                Tabla += "<tr>";
                Tabla += "<td>TOTAL</td><td>" + Total.ToString() + "</td>";
                Tabla += "</tr>";

                Tabla += "</table>";


                lblTabla.Text = Tabla;
                txtProducto1.Text = string.Empty;
                txtProducto2.Text = string.Empty;
                txtCantidad1.Text = string.Empty;
                txtCantidad2.Text = string.Empty;

            }

        }

           
    }

}

