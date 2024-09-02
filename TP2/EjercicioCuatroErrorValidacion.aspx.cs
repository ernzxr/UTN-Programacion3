using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP2
{
    public partial class EjercicioCuatroErrorValidacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "USUARIO INVALIDO, INGRESO NO PERMITIDO";
        }

        protected void btnIngresoUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("EjercicioCuatro.aspx");
        }
    }
}