using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Vistas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
           
            string usuario = txtUsuario.Text;
            string contraseña = txtPass.Text;

           
            NegocioUsuario negocioUsuario = new NegocioUsuario();

           
            string tipoUsuario = negocioUsuario.VerificarUsuario(usuario, contraseña);

            if (tipoUsuario == "Administrador")
            {
                Session["TipoUsuario"] = 1;
                Session["Usuario"] = txtUsuario.Text;
                Response.Redirect("InicioAdmin.aspx");
            }
            else if (tipoUsuario == "Médico")
            {
                Session["TipoUsuario"] = 2;
                Session["Usuario"] = txtUsuario.Text;
                Response.Redirect("InicioMedico.aspx");
            }
            else if (tipoUsuario == "El usuario debe ingresarse solo en minúsculas.")
            {
                // Mostramos un mensaje de error para casos de mayúsculas
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Por favor, ingrese el usuario solo en minúsculas.";
                txtUsuario.Text = "";
            }
            else if (tipoUsuario == "Credenciales incorrectas")
            {
                // Mostramos un mensaje de error si las credenciales no coinciden
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Usuario o contraseña incorrectos.";
                txtUsuario.Text = "";
            }
            else
            {
                // Mensaje genérico para usuarios no reconocidos
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Tipo de usuario no reconocido.";
                txtUsuario.Text = "";
            }

        }
        

    }
}
