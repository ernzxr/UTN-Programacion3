using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP2
{
    public partial class EjercicioCuatro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnValidar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() != "" && txtClave.Text.Trim() != "")
            {
                String usuario = txtUsuario.Text.Trim();
                String vUsuario = "claudio";
                String clave = txtClave.Text.Trim();
                String vClave = "casas";

                if (usuario == vUsuario && clave == vClave)
                {
                    Response.Redirect("EjercicioCuatroValida.aspx");
                }
                else
                {
                    Response.Redirect("EjercicioCuatroErrorValidacion.aspx");
                }

            }
            else
            {
                Response.Redirect("EjercicioCuatroErrorValidacion.aspx");
            }
        }
    }
}