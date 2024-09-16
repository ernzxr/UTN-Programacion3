using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TP4
{
    public partial class Ejercicio3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           string rutaLibreria = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True";
          
            if (!IsPostBack)
            {
                SqlConnection cn = new SqlConnection(rutaLibreria);
                cn.Open();

               SqlCommand cmd = new SqlCommand ("SELECT * FROM Temas", cn);

               SqlDataReader dr = cmd.ExecuteReader();


                ddlTemas.DataSource = dr;
                ddlTemas.DataTextField = "Tema";
                ddlTemas.DataValueField = "IdTema";
                ddlTemas.DataBind();

                cn.Close();
                           

            }
        }

        protected void lbVerLibros_Click(object sender, EventArgs e)
        {
           string temaSeleccionado = ddlTemas.SelectedValue;
           Response.Redirect("Ejercicio3_b.aspx?Temas= " + temaSeleccionado);
            
        }
    }
}