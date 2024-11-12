using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class ListadoPacientes : System.Web.UI.Page
    {
        NegocioNacionalidad negn = new NegocioNacionalidad();
        NegocioPaciente NegP = new NegocioPaciente(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if(!IsPostBack)
            {
                CargarNacionalidad();
            }
            
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

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string dni = txtDNI.Text;
            int idNacionalidad = int.Parse(ddlNacionalidad.SelectedValue); 

            if (NegP.existePaciente(dni, idNacionalidad))
            {
                gvPacientes.DataSource = NegP.getPaciente(dni, idNacionalidad);
                gvPacientes.DataBind();

                txtDNI.Text = "";
                ddlNacionalidad.SelectedValue = "0";

            }
        }

        protected void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            gvPacientes.DataSource = NegP.getPacientes();
            gvPacientes.DataBind();

            txtDNI.Text = "";
            ddlNacionalidad.SelectedValue = "0";
        }
    }
}