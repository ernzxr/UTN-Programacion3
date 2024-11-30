using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Vistas
{
    public partial class CambiarContraseña : System.Web.UI.Page
    {
        private NegocioUsuario _usuarioNegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            _usuarioNegocio = new NegocioUsuario(); 
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            string usuario = txtUsuario.Text.Trim();
            string email = txtEmail.Text.Trim();
            string nuevaClave = txtClave.Text.Trim();
            string confirmarClave = txtConfirmarClave.Text.Trim();

            // Llamar al método de negocio que devuelve el mensaje de éxito o error
            string resultado = _usuarioNegocio.CambiarContraseña(usuario, email, nuevaClave);

            lblMensaje.Text = resultado;

            // Verificar el mensaje de resultado
            if (resultado == "Contraseña actualizada correctamente.")
            {
               
                lblMensaje.ForeColor = System.Drawing.Color.Green; // Mensaje de éxito
                txtUsuario.Text = "";
                txtEmail.Text = "";
                txtClave.Text = "";
                txtConfirmarClave.Text = "";
            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red; // Mensaje de error
                txtUsuario.Text = "";
                txtEmail.Text = "";
                txtClave.Text = "";
                txtConfirmarClave.Text = "";
            }
        }
    }
}
           
    



    

