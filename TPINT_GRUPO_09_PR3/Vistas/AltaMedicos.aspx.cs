using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class AltaMedicos : System.Web.UI.Page
    {
        NegocioNacionalidad nNacionalidad = new NegocioNacionalidad();
        NegocioProvincia nProvincia = new NegocioProvincia();
        NegocioEspecialidad nEspecialidad = new NegocioEspecialidad();
        NegocioLocalidad nLocalidad = new NegocioLocalidad();
        NegocioMedico nMedico = new NegocioMedico();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                CargarNacionalidad();
                CargarProvincia();
                CargarEspecialidad();
                ddlLocalidad.Items.Insert(0, new ListItem("---Debe seleccionar una provincia---", "0"));

            }
        }

        public void CargarNacionalidad()
        {
            DataTable Nacionalidad = nNacionalidad.getTablaNacionalidad();
            ddlNacionalidad.DataSource = Nacionalidad;
            ddlNacionalidad.DataTextField = "Descripcion_Na";
            ddlNacionalidad.DataValueField = "Id_Nacionalidad_Na";
            ddlNacionalidad.DataBind();

            ddlNacionalidad.Items.Insert(0, new ListItem("---Seleccionar---", "0"));

        }

        public void CargarEspecialidad()
        {
            DataTable Especialidad = nEspecialidad.getTablaEspecialidad();
            ddlEspecialidad.DataSource = Especialidad;
            ddlEspecialidad.DataTextField = "Descripcion_Es";
            ddlEspecialidad.DataValueField = "Id_Especialidad_Es";
            ddlEspecialidad.DataBind();

            ddlEspecialidad.Items.Insert(0, new ListItem(" --- Seleccionar ---", "0"));

        }

        public void CargarProvincia()
        {
            DataTable Provincia = nProvincia.getTablaProvincia();
            ddlProvincia.DataSource = Provincia;
            ddlProvincia.DataTextField = "Descripcion_Pr";
            ddlProvincia.DataValueField = "Id_Provincia_Pr";
            ddlProvincia.DataBind();

            ddlProvincia.Items.Insert(0, new ListItem(" --- Seleccionar---", "0"));

        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProv = Convert.ToInt32(ddlProvincia.SelectedValue);

            DataTable Localidad = nLocalidad.getTablaLocalidad(idProv);
            ddlLocalidad.DataSource = Localidad;
            ddlLocalidad.DataTextField = "Descripcion_Lo";
            ddlLocalidad.DataValueField = "Id_Localidad_Lo";
            ddlLocalidad.DataBind();

            ddlLocalidad.Items.Insert(0, new ListItem("---Seleccionar---", "0"));
        }

        public void LimpiarCampos()
        {
            txtLegajo.Text = "";
            ddlLocalidad.SelectedValue = "0";
            ddlEspecialidad.SelectedValue = "0";
            ddlNacionalidad.SelectedValue = "0";
            txtUsuario.Text = "";
            txtDNI.Text = "";
            txtCorreoElectronico.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtFechaNacimiento.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            lblMensaje.Text = "";

            if (rblGenero.SelectedIndex == -1)
            {
                lblMensaje.Text = "Por favor, seleccione un género.";
                return; 
            }

            string legajo = txtLegajo.Text;
            int idLocalidad = Convert.ToInt32(ddlLocalidad.SelectedValue);
            int idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue);
            int idNacionalidad = Convert.ToInt32(ddlNacionalidad.SelectedValue);
            int idGenero = Convert.ToInt32(rblGenero.SelectedValue);
            string usuario = txtUsuario.Text;
            string dni = txtDNI.Text;
            string email = txtCorreoElectronico.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            DateTime fechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text;
            bool estado = true;   // suponemos que esta activo al momento de agregarlo

            bool resultado = nMedico.agregarMedico(legajo, idLocalidad, idEspecialidad, idNacionalidad, idGenero, usuario, dni, email, nombre, apellido, fechaNacimiento, direccion, telefono, estado);

            if (resultado)
            {
                
                lblMensaje.Text = "Médico agregado exitosamente.";
                LimpiarCampos();
            }
            else
            {
                
                lblMensaje.Text = "Hubo un error al agregar el médico.";
            }
        }

        protected void btnCargarHorarios_Click(object sender, EventArgs e)
        {
           Response.Redirect("CargaDiasYHorariosMedicos.aspx");
        }

    }
    
}










