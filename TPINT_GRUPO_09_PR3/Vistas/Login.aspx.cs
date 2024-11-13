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
            // Obtén el nombre de usuario y la contraseña desde los controles de la página
            string usuario = txtUsuario.Text;
            string contraseña = txtPass.Text;

            // Instancia de NegocioUsuario
            NegocioUsuario negocioUsuario = new NegocioUsuario();

            // Verifica el tipo de usuario
            string tipoUsuario = negocioUsuario.VerificarUsuario(usuario, contraseña);

            if (tipoUsuario == "Administrador")
            {
                // Redirige a la página de administrador
                Session["TipoUsuario"] = 1;
                Response.Redirect("InicioAdmin.aspx");
            }
            else if (tipoUsuario == "Médico")
            {
                // Redirige a la página de médico
                Session["TipoUsuario"] = 2;
                Response.Redirect("InicioMedico.aspx");
            }
            else
            {
                // Muestra un mensaje de error si las credenciales son incorrectas
                Session.Clear();
                lblError.Text = "Credenciales incorrectas";
            }
        }
    }
}
