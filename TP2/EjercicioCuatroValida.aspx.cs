using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP2
{
    public partial class Ejercicio_4_Valida : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string NombreUsuario = string.Empty;
            string ClaveUsuario = string.Empty;

            if (Request["txtUsuario"] != null && Request["txtClave"] != null)
            {
                NombreUsuario = Request["txtUsuario"].ToString().ToUpper();


            }

            lblValida.Text = " Bienvenido a mi página Sr./a: " + NombreUsuario + "!!!";
        }
    }
}