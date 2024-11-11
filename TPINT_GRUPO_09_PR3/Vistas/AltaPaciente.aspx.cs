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
            int idProv = Convert.ToInt32(ddlProvincia.SelectedValue);

            DataTable Localidad = negl.getTablaLocalidad(idProv);
            ddlLocalidad.DataSource = Localidad;
            ddlLocalidad.DataTextField = "Descripcion_Lo";
            ddlLocalidad.DataValueField = "Id_Localidad_Lo";
            ddlLocalidad.DataBind();

            ddlLocalidad.Items.Insert(0, new ListItem("Seleccionar...", "0"));
        }
    }
}