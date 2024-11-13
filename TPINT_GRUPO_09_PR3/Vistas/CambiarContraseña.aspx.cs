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
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            // Recogemos los valores ingresados por el usuario
            string email = txtEmail.Text.Trim();
            string usuario = txtUsuario.Text.Trim();
            string nuevaContrasena = txtNueva.Text;
            string confirmarNuevaContrasena = txtConfirmar.Text;

            // Verificar si las contraseñas coinciden
            if (nuevaContrasena != confirmarNuevaContrasena)
            {
                lblMensaje.Text = "La nueva contraseña y la confirmación no coinciden.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                // Llamamos al método para cambiar la contraseña
                NegocioUsuario negocioUsuario = new NegocioUsuario();
                bool cambioExitoso = negocioUsuario.CambiarContrasena(email, usuario, nuevaContrasena);

                // Mostrar el resultado
                if (cambioExitoso)
                {
                    MostrarMensaje("Contraseña cambiada exitosamente.", System.Drawing.Color.Green);
                }
                else
                {
                    MostrarMensaje("Los datos proporcionados no son correctos.", System.Drawing.Color.Red);
                }
            }
            catch (Exception ex)
            {
                // En caso de error inesperado
                MostrarMensaje("Ocurrió un error al cambiar la contraseña. Inténtelo más tarde.", System.Drawing.Color.Red);
                // Aquí podrías loguear el error en un archivo o base de datos
            }
        }

        // Método para mostrar mensajes con colores
        private void MostrarMensaje(string mensaje, System.Drawing.Color color)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = color;
        }
    }


}
    

