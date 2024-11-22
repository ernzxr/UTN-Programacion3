using Entidades;
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
        NegocioUsuario nUsuario = new NegocioUsuario();
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
            //int idProv = Convert.ToInt32(ddlProvincia.SelectedValue);

            //DataTable Localidad = nLocalidad.getTablaLocalidad(idProv);
            //ddlLocalidad.DataSource = Localidad;
            //ddlLocalidad.DataTextField = "Descripcion_Lo";
            //ddlLocalidad.DataValueField = "Id_Localidad_Lo";
            //ddlLocalidad.DataBind();

            //ddlLocalidad.Items.Insert(0, new ListItem("---Seleccionar---", "0"));
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
            txtUsuario.Text = "";
            txtPassword.Text = "";
            rblGenero.SelectedValue = "";
            txtPasswordRepetida.Text = "";
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            if (Page.IsValid)
            {
                if (!nUsuario.existeUsuario(txtUsuario.Text) &&
                !nMedico.existeLegajo(txtLegajo.Text) &&
                !nMedico.existeMedico(txtDNI.Text, Convert.ToInt32(ddlNacionalidad.SelectedValue)))
                {
                    Usuario user = new Usuario();

                    user.SetUsuarioUs(txtUsuario.Text);
                    user.SetClaveUs(txtPassword.Text);
                    user.SetEmailUs(txtUsuario.Text + "@clinica.com.ar");
                    user.SetIdTipoUsuario(2);

                    Medico medico = new Medico();

                    medico.setLegajo(txtLegajo.Text);
                    medico.setIdLocalidad(Convert.ToInt32(ddlLocalidad.SelectedValue));
                    medico.setIdEspecilidad(Convert.ToInt32(ddlEspecialidad.SelectedValue));
                    medico.setIdNacionalidad(Convert.ToInt32(ddlNacionalidad.SelectedValue));
                    medico.setIdGenero(Convert.ToInt32(rblGenero.SelectedValue));
                    medico.setUsuario(txtUsuario.Text);
                    medico.setDni(txtDNI.Text);
                    medico.setEmail(txtCorreoElectronico.Text);
                    medico.setNombre(txtNombre.Text);
                    medico.setApellido(txtApellido.Text);
                    medico.setFechaNacimiento(Convert.ToDateTime(txtFechaNacimiento.Text));
                    medico.setDireccion(txtDireccion.Text);
                    medico.setTelefono(txtTelefono.Text);

                    if (!nUsuario.agregarUsuario(user))
                    {
                        lblMensaje.Text = "Hubo un error al agregar el usuario.";
                        return;
                    }

                    if (nMedico.agregarMedico(medico))
                    {

                        lblMensaje.Text += "Médico agregado exitosamente.";
                        LimpiarCampos();
                    }
                    else
                    {
                        lblMensaje.Text = "Hubo un error al agregar el médico.";
                    }
                }
            }
        }


        protected void cvExisteUsuario_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (nUsuario.existeUsuario(txtUsuario.Text))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void cvExisteLegajo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (nMedico.existeLegajo(txtLegajo.Text))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
    }
}










