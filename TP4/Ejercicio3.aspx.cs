using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.EnterpriseServices;
using System.Data.SqlTypes;

namespace TP4
{
    public partial class Ejercicio3 : System.Web.UI.Page
    {
        private SqlDataReader cargarDataReader(SqlConnection cn, string cmd)
        {
            SqlCommand consulta = new SqlCommand(cmd, cn);
            return consulta.ExecuteReader();
        }

        private void cargarDdl(SqlDataReader dr, string item, string value)
        {
            ddlTemas.DataSource = dr;
            ddlTemas.DataTextField = item;
            ddlTemas.DataValueField = value;
            ddlTemas.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           string rutaLibreria = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True";
            
           if (!IsPostBack)
            {
                SqlConnection cn = new SqlConnection(rutaLibreria);
                cn.Open();

                SqlDataReader dr = cargarDataReader(cn, "SELECT * FROM Temas");

                cargarDdl(dr, "Tema", "IdTema");

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