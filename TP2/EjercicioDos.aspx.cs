using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP2
{
    public partial class EjercicioDos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(isPostBack == false)
            {
                lblMensaje.Visible = false;
            }
        }
        protected void btnVer_Click(object sender, EventArgs e)
        {
            /*if(ddlCiudad.SelectedIndex == 0)
            {
                lblMensaje.Text = "Debe seleccionar una opcion valida, intente de nuevo.";
            }
            else
            {
                Server.Transfer("EjercicioDos-WebForm2.aspx");
            }*/

            if (txtNombre.Text.Trim() != "" && txtApellido.Text.Trim() != "" && !String.IsNullOrEmpty(ddlCiudad.SelectedValue) && !String.IsNullOrEmpty(chbTemas.SelectedValue))
            {
                Server.Transfer("EjercicioDos-WebForm2.aspx");
            }
            else 
            {
                lblMensaje.Text = "Por favor, completar todos los campos antes de continuar";
                lblMensaje.Visible = true;
            }

        }
    }
}