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
                    // Instanciar la clase NegocioMedico
                    NegocioMedico negocioMedico = new NegocioMedico();

                    // Obtener los datos del médico por usuario
                    var datosMedico = negocioMedico.ObtenerDatosMedicoPorUsuario(usuario);

                    if (datosMedico.legajo != null)
                    {
                        // Asignar los valores obtenidos a los controles del formulario
                        txtLegajo.Text = datosMedico.legajo;
                        txtNombre.Text = datosMedico.nombre;
                        txtApellido.Text = datosMedico.apellido;
                        txtDni.Text = datosMedico.dni;
                        txtUsuario.Text = usuario;
                        if (datosMedico.fechaNacimiento != default(DateTime))
                        {
                            // Usar el formato directamente sin necesidad de TryParse
                            txtNacimiento.Text = datosMedico.fechaNacimiento.ToString("dd/MM/yyyy"); // Ajuste de formato
                        }
                        else
                        {
                            txtNacimiento.Text = ""; // Si no es válida, dejamos el campo vacío
                        }
                        txtDireccion.Text = datosMedico.direccion;
                        txtTelefono.Text = datosMedico.telefono;
                        txtEmail.Text = datosMedico.email;

                        // Asignar los valores de las otras propiedades descriptivas
                        txtEspecialidad.Text = datosMedico.nombreEspecialidad;
                        txtLocalidad.Text = datosMedico.nombreLocalidad;
                        txtProvincia.Text = datosMedico.nombreProvincia;
                        txtNacionalidad.Text = datosMedico.nombreNacionalidad;
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