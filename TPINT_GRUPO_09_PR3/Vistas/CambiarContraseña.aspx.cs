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
            // Obtener los valores ingresados por el usuario
            string usuario = txtUsuario.Text.Trim();
            string email = txtEmail.Text.Trim();
            string nuevaClave = txtClave.Text.Trim();
            string confirmarClave = txtConfirmarClave.Text.Trim();

          
           

            // Llamar al método de negocio para cambiar la contraseña
            bool exito = _usuarioNegocio.CambiarContraseña(usuario, email, nuevaClave);

            // Mostrar mensaje según el resultado
            if (exito)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = "La contraseña se ha actualizado correctamente.";
                txtUsuario.Text = "";
                txtEmail.Text = "";
                txtClave.Text = "";
                txtConfirmarClave.Text = "";
               // Response.Redirect("Login.aspx");
            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "El usuario o el email no son válidos.";
                txtUsuario.Text = "";
                txtEmail.Text = "";
                txtClave.Text = "";
                txtConfirmarClave.Text = "";
            }
        }
    }
}
           
    



    

