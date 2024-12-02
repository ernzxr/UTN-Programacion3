using Negocio;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Vistas
{
    public partial class TicketTurnosPendientesPorPaciente : System.Web.UI.Page
    {
        NegocioNacionalidad NegNac = new NegocioNacionalidad();
        NegocioPaciente NegPac = new NegocioPaciente();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (IsPostBack == false)
            {
                CargarNacionalidad();
            }

        }
        public void CargarNacionalidad()
        {
            DataTable nacionalidad = NegNac.getTablaNacionalidad();
            ddlNacionalidad.DataSource = nacionalidad;
            ddlNacionalidad.DataTextField = "Descripcion_Na";
            ddlNacionalidad.DataValueField = "Id_Nacionalidad_Na";
            ddlNacionalidad.DataBind();

            ddlNacionalidad.Items.Insert(0, new ListItem("Seleccionar...", "0"));

        }
        public void LimpiarCampos()
        {
            ddlNacionalidad.SelectedValue = "0";
            txtDniPaciente.Text = "";
        }

        protected void btnFiltrarPaciente_Click(object sender, EventArgs e)

        {
            string dni = txtDniPaciente.Text;
            int idNacionalidad = int.Parse(ddlNacionalidad.SelectedValue);

            if (NegPac.existePaciente(dni, idNacionalidad))
            {
                DataTable dt = NegPac.ObtenerTurnosPorPaciente(dni, idNacionalidad);

                gvTicketTurnos.DataSource = dt;
                gvTicketTurnos.DataBind();
                Session["DatosFiltrados"] = dt;

                txtDniPaciente.Text = "";
                ddlNacionalidad.SelectedValue = "0";
                lblError_Filtrar.Text = "";

            }
            else
            {
                gvTicketTurnos.DataSource = null;
                gvTicketTurnos.DataBind();
                lblError_Filtrar.Text = "No existe el paciente/fue dado de baja.";
            }


        }


        protected void gvTicketTurno_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTicketTurnos.PageIndex = e.NewPageIndex;

            // Verificar si hay datos filtrados almacenados en Session
            if (Session["DatosFiltrados"] != null)
            {
                // Recuperar los datos filtrados
                DataTable dt = (DataTable)Session["DatosFiltrados"];

                // Recargar el GridView con los datos filtrados
                gvTicketTurnos.DataSource = dt;
                gvTicketTurnos.DataBind();
            }
            else
            {
                gvTicketTurnos.DataSource = null;
                gvTicketTurnos.DataBind();
                lblError_Filtrar.Text = "No existe el paciente/fue dado de baja.";

            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            string script = "<script type='text/javascript'>window.print();</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "print", script);

        }
    }

}


















