using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing.Printing;
using System.Drawing;

namespace TP4
{
    public partial class Ejercicio3_b : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string rutaLibreria = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True";
                string temaSeleccionado = Request["Temas"];
                
                if(string.IsNullOrEmpty(temaSeleccionado))
                {
                    return;
                }
                else
                {
                    SqlConnection cn = new SqlConnection(rutaLibreria);
                    cn.Open();

                    SqlCommand cmd = new SqlCommand();

                    cmd.Parameters.AddWithValue("@IdTema", temaSeleccionado);
                    cmd.CommandText = "SELECT * FROM Libros WHERE @IdTema = IdTema";
                    cmd.Connection = cn;

                    SqlDataReader dr = cmd.ExecuteReader();

                    gv_Libros.DataSource = dr;
                    gv_Libros.DataBind();

                    dr.Close();

                    cn.Close();
                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ejercicio3.aspx");
        }
    }
}
