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
             /* rfvDniPaciente.ValidationGroup = "Grupo1";
             revDniPaciente.ValidationGroup = "Grupo1";
             rfvNacionalidad.ValidationGroup = "Grupo1";

             if (Page.IsValid)
             {

                 string dni = txtDniPaciente.Text.Trim();
                 int idNacionalidadSeleccionada = Convert.ToInt32(ddlNacionalidad.SelectedValue);


                 if (NegPac.existePaciente(dni, idNacionalidadSeleccionada))
                 {
                     DataTable dt = NegPac.getPaciente(dni, idNacionalidadSeleccionada);

                     if (dt.Rows.Count == 0)
                     {
                         lblError_Filtrar.Text = "No se encontraron turnos para el paciente.";
                         gvTicketTurnos.DataSource = null;
                         gvTicketTurnos.DataBind();
                         return;
                     }


                     if (!dt.Columns.Contains("FECHA"))
                         dt.Columns.Add("FECHA", typeof(DateTime));

                     if (!dt.Columns.Contains("TURNO"))
                         dt.Columns.Add("TURNO", typeof(DateTime));

                     if (!dt.Columns.Contains("ESPECIALIDAD"))
                         dt.Columns.Add("ESPECIALIDAD", typeof(string));

                     if (!dt.Columns.Contains("PROFESIONAL"))
                         dt.Columns.Add("PROFESIONAL", typeof(string));



                     gvTicketTurnos.DataSource = dt;
                     gvTicketTurnos.DataBind();



                     LimpiarCampos();
                     lblError_Filtrar.Text = "";
                 }
                 else
                 {
                     gvTicketTurnos.DataSource = null;
                     gvTicketTurnos.DataBind();
                     lblError_Filtrar.Text = "No existe el paciente/fue dado de baja.";
                 }
            */
                string dni = txtDniPaciente.Text;
                int idNacionalidad = int.Parse(ddlNacionalidad.SelectedValue);

                if (NegPac.existePaciente(dni, idNacionalidad))
                {
                    DataTable dt = NegPac.ObtenerTurnosPorPaciente(dni, idNacionalidad);
                   
                    gvTicketTurnos.DataSource = dt;
                    gvTicketTurnos.DataBind();
                   

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
            int contiene = Convert.ToInt32(Session["contiene"]);
            gvTicketTurnos.PageIndex = e.NewPageIndex;
            gvTicketTurnos.DataSource = Session["dtAmbos"];
            gvTicketTurnos.DataBind();
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            string script = "<script type='text/javascript'>window.print();</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "print", script);
           
        }
    }

 }


















