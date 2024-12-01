using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class ModificarUsuario : System.Web.UI.Page
    {
        private NegocioUsuario negocioUsuario = new NegocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
             int idUsuario;
            if (int.TryParse(txtIdUsuario.Text, out idUsuario))
            {
              
                bool existe = negocioUsuario.existeIdUsuario(idUsuario);

                if (existe)
                {
                    lblMensaje.Text = "";
                    pnlModificacion.Visible = true;
                   
                    //CargarUsuario(idUsuario);
                }
                else
                {
                    // Si no existe, muestra un mensaje
                    txtIdUsuario.Text = "";
                    pnlModificacion.Visible = false;
                    lblMensaje.Text = "El ID de usuario no existe.";
                   

                }
            }
            else
            {
                txtIdUsuario.Text = "";
                lblMensaje.Text = "Por favor, ingresa un ID válido.";
                pnlModificacion.Visible = false;
            }
        }

        
        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}