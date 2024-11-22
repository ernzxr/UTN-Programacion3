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
    public partial class AltaPaciente : System.Web.UI.Page
    {
        NegocioSexo negs = new NegocioSexo();
        NegocioNacionalidad negn = new NegocioNacionalidad();
        NegocioProvincia negp = new NegocioProvincia();
        NegocioLocalidad negl = new NegocioLocalidad();
        NegocioPaciente negpaciente = new NegocioPaciente();
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (IsPostBack == false)
            {
                CargarSexo();
                CargarNacionalidad();
                CargarProvincia();
                ddlLocalidad.Items.Insert(0, new ListItem("Seleccione una provincia primero", "0"));
            }
        }


        public void CargarSexo()
        {
            DataTable sexo = negs.getTablaSexo();
            ddlSexo.DataSource = sexo;
            ddlSexo.DataTextField = "Descripcion_Ge";
            ddlSexo.DataValueField = "Id_Genero_Ge";
            ddlSexo.DataBind();

            ddlSexo.Items.Insert(0, new ListItem("Seleccionar...", "0"));
        }

        public void CargarNacionalidad()
        {
            DataTable Nacionalidad = negn.getTablaNacionalidad();
            ddlNacionalidad.DataSource = Nacionalidad;
            ddlNacionalidad.DataTextField = "Descripcion_Na";
            ddlNacionalidad.DataValueField = "Id_Nacionalidad_Na";
            ddlNacionalidad.DataBind();

            ddlNacionalidad.Items.Insert(0, new ListItem("Seleccionar...", "0"));
        }

        public void CargarProvincia()
        {
            DataTable Provincia = negp.getTablaProvincia();
            ddlProvincia.DataSource = Provincia;
            ddlProvincia.DataTextField = "Descripcion_Pr";
            ddlProvincia.DataValueField = "Id_Provincia_Pr";
            ddlProvincia.DataBind();

            ddlProvincia.Items.Insert(0, new ListItem("Seleccionar...", "0"));
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int idProv = Convert.ToInt32(ddlProvincia.SelectedValue);

            //DataTable Localidad = negl.getTablaLocalidad(idProv);
            //ddlLocalidad.DataSource = Localidad;
            //ddlLocalidad.DataTextField = "Descripcion_Lo";
            //ddlLocalidad.DataValueField = "Id_Localidad_Lo";
            //ddlLocalidad.DataBind();

            //ddlLocalidad.Items.Insert(0, new ListItem("Seleccionar...", "0"));
        }

        public void limpiarCampos()
        {
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            ddlSexo.SelectedValue = "0";
            txtFechaNacimiento.Text = "";
            ddlNacionalidad.SelectedValue = "0";
            ddlLocalidad.SelectedValue = "0";
            txtDireccion.Text = "";
            txtCorreoElectronico.Text = "";
            txtTelefono.Text = "";
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";

            int sexo = Convert.ToInt32(ddlSexo.SelectedValue);
            int idNacionalidad = Convert.ToInt32(ddlNacionalidad.SelectedValue);
            int idLocalidad = Convert.ToInt32(ddlLocalidad.SelectedValue);
            DateTime fechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);

            if (!negpaciente.existePaciente(txtDNI.Text, idLocalidad))
            {
                if (!negpaciente.existeEmail(txtCorreoElectronico.Text))
                {

                    bool agrego = negpaciente.agregarPaciente(txtDNI.Text, txtNombre.Text, txtApellido.Text, sexo, fechaNacimiento, idNacionalidad, idLocalidad, txtDireccion.Text, txtCorreoElectronico.Text, txtTelefono.Text, true);

                    if (agrego)
                    {
                        lblMensaje.ForeColor = System.Drawing.Color.Blue;
                        lblMensaje.Text = "El paciente se agregó correctamente.";
                        limpiarCampos();
                    }
                    else
                    {
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        lblMensaje.Text = "No se pudo agregar el paciente.";
                    }
                }
                else
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Orange;
                    lblMensaje.Text = "El correo electronico ingresado ya existe. Pruebe con otro.";
                }
            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Purple;
                lblMensaje.Text = "Ya existe un paciente registrado con ese DNI y Nacionalidad.";
            }
        }
    }
}