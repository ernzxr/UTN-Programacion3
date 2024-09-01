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
            if (!IsPostBack)
            {
                lblMensaje.Visible = false;

                /* ddlCiudad.ClearSelection();
                 ddlCiudad.Items.Add("Pacheco");
                 ddlCiudad.Items.Add("San Miguel");
                 ddlCiudad.Items.Add("Boedo");

                 chbTemas.ClearSelection();
                 chbTemas.Items.Add("Ciencias");
                 chbTemas.Items.Add("Literatura");
                 chbTemas.Items.Add("Historia");*/
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

            var temasSeleccionados = new List<string>();

            foreach (ListItem item in chbTemas.Items)
            {
                if (item.Selected)
                {
                    if (temasSeleccionados.Count == 0)
                    {
                        temasSeleccionados.Add("<br/>" + item.Text);
                    }
                    else
                    {
                        temasSeleccionados.Add(item.Text);
                    }
                }
            }

            Session["temasElegidos"] = string.Join("<br/>", temasSeleccionados);

            if (txtNombre.Text.Trim() != ""
                && txtApellido.Text.Trim() != ""
                && ddlCiudad.SelectedValue != "Seleccione una opcion"
                && !String.IsNullOrEmpty(chbTemas.SelectedValue))
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