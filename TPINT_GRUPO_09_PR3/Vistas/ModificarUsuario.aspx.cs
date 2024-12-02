using Entidades;
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
        Usuario usuario = new Usuario();
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
            // Obtener los datos del usuario desde los TextBox
            int idUsuario = Convert.ToInt32(txtIdUsuario.Text);
            string usuarioNuevo = txtUsuario.Text;
            string claveNueva = txtPassword.Text;
            string emailNuevo = usuarioNuevo + "@clinica.com.ar";

            // Crear el objeto Usuario con los nuevos datos
            usuario.SetIdUsuario(idUsuario); 
            usuario.SetUsuarioUs(usuarioNuevo);
            usuario.SetClaveUs(claveNueva);
            usuario.SetEmailUs(emailNuevo);

            // Verificar si el nombre de usuario ya está en uso
            if (negocioUsuario.existeNombreUsuario(usuarioNuevo))
            {
                // Si el nombre de usuario ya está en uso, mostrar un mensaje y no continuar
                lblMensaje.Text = "El nombre de usuario ya está en uso. Elija otro.";
                return;  
            }
            else
            {
                // Llamar al método de la capa de negocio para modificar el usuario
                bool exito = negocioUsuario.modificarUsuario(usuario); 
                                                                     
                if (exito)
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    lblMensaje.Text = "Usuario modificado correctamente.";
                }
                else
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "Hubo un error al modificar el usuario.";
                }
            }

          
        }
   

        protected void cvExisteUsuario_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (negocioUsuario.existeUsuario(txtUsuario.Text))
            { 
                args.IsValid = false;
                txtUsuario.Text = "";
            }
            else
            {   
                args.IsValid = true;
            }
        }

        // Validación para el email
        protected void cvExisteEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Verificar si el email ya existe en la base de datos
            if (negocioUsuario.existeEmail(txtEmail.Text))
            {
                // Si el email ya existe, la validación falla y se muestra el mensaje
                args.IsValid = false;
                txtEmail.Text = "";
            }
            else
            {
                // Si el email no existe, la validación es exitosa
                args.IsValid = true;
            }
        }
    }
 }
    
