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
               
                lblMensaje.ForeColor = System.Drawing.Color.Green; 
                txtUsuario.Text = "";
                txtEmail.Text = "";
                txtClave.Text = "";
                txtConfirmarClave.Text = "";
            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red; 
                txtUsuario.Text = "";
                txtEmail.Text = "";
                txtClave.Text = "";
                txtConfirmarClave.Text = "";
            }
        }
        protected void cvExisteUsuario_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (_usuarioNegocio.existeUsuario(txtUsuario.Text))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        // Validación para el email
        protected void cvExisteEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Verificar si el email ya existe en la base de datos
            if (_usuarioNegocio.existeEmail(txtEmail.Text))
            {
                // Si el email ya existe no muestro nada
                args.IsValid = true;
            }
            else
            {
                // Si el email no existe muestro mensaje
                args.IsValid = false;
            }
        }
        
    }
}
           
    



    

