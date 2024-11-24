using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
        NegocioLocalidad negocioLocalidad = new NegocioLocalidad();
        NegocioProvincia negocioProvincia = new NegocioProvincia();
        NegocioNacionalidad negocioNacionalidad = new NegocioNacionalidad();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

                if (Session["Legajo"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                CargarPerfilMedico();
            }
        }

        public void CargarPerfilMedico()
        {
            string usuario = (string)Session["Usuario"]; // Suponiendo que el usuario está en sesión
            if (!string.IsNullOrEmpty(usuario))
            {
                // Instanciar la clase NegocioMedico
                NegocioMedico negocioMedico = new NegocioMedico();

                // Obtener los datos del médico por usuario
                Medico datosMedico = negocioMedico.ObtenerDatosMedicoPorUsuario(usuario);

                if (datosMedico.getLegajo() != null)
                {
                    // Asignar los valores obtenidos a los controles del formulario
                    txtLegajo.Text = datosMedico.getLegajo();
                    txtNombre.Text = datosMedico.getNombre();
                    txtApellido.Text = datosMedico.getApellido();
                    txtDni.Text = datosMedico.getDni();
                    txtUsuario.Text = usuario;
                    txtNacimiento.Text = datosMedico.getFechaNacimiento().ToString("dd/MM/yyyy");
                    txtDireccion.Text = datosMedico.getDireccion();
                    txtTelefono.Text = datosMedico.getTelefono();
                    txtEmail.Text = datosMedico.getEmail();

                    // Asignar los valores de las otras propiedades descriptivas
                    txtEspecialidad.Text = negocioEspecialidad.getDescripcionEspecialidad(datosMedico.getIdEspecialidad());
                    txtLocalidad.Text = negocioLocalidad.getDescripcionLocalidad(datosMedico.getIdLocalidad());

                    int idProvincia = negocioLocalidad.getIdProvincia(datosMedico.getIdLocalidad());

                    txtProvincia.Text = negocioProvincia.getDescripcionProvincia(idProvincia);
                    txtNacionalidad.Text = negocioNacionalidad.getDescripcionNacionalidad(datosMedico.getNacionalidad());
                }
                else
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "No se encontraron datos para el usuario.";
                }
            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Usuario no válido.";
            }
        }
    }
}