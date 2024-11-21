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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string usuario = (string)Session["Usuario"]; // Suponiendo que el usuario está en sesión
                if (!string.IsNullOrEmpty(usuario))
                {
                    NegocioMedico negocioMedico = new NegocioMedico();
                    Medico medico = negocioMedico.ObtenerDatosMedicoPorUsuario(usuario);

                    if (medico != null)
                    {
                        txtLegajo.Text = medico.getLegajo();
                        txtNombre.Text = medico.getNombre();
                        txtApellido.Text = medico.getApellido();
                        txtDni.Text = medico.getDni();
                        txtNacimiento.Text = medico.getFechaNacimiento().ToShortDateString();
                        txtDireccion.Text = medico.getDireccion();
                        txtTelefono.Text = medico.getTelefono();
                        txtEmail.Text = medico.getEmail();

                        // Obtener nombres descriptivos de Localidad, Especialidad y Nacionalidad
                       // txtLocalidad.Text = negocioMedico.ObtenerNombreLocalidad(medico.getIdLocalidad());
                        //txtEspecialidad.Text = negocioMedico.ObtenerNombreEspecialidad(medico.getIdEspecialidad());
                       // txtNacionalidad.Text = negocioMedico.ObtenerNombreNacionalidad(medico.getNacionalidad());
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
}