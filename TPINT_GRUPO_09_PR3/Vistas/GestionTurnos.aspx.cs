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
    public partial class GestionTurnos : System.Web.UI.Page
    {
        NegocioTurno negocioTurno = new NegocioTurno();
        NegocioMedico negocioMedico = new NegocioMedico();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                CargarTurnos();
            }
        }

        private void CargarTurnos()
        {
            DataTable dt = negocioTurno.getTurnosPendientes();
            gvTurnos.DataSource = dt;
            gvTurnos.DataBind();
        }

        protected void gvTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTurnos.PageIndex = e.NewPageIndex;
            CargarTurnos();
        }

        protected void CargarDDLMedicosEspecialidad(int idEspecialidad)
        {
            DataTable dt = negocioMedico.getTablaMedicoSegunEspecialidad(idEspecialidad);

            ddlMedicosEspecialidad.DataSource = dt;
            ddlMedicosEspecialidad.DataTextField = "Nombre_Completo_Me";
            ddlMedicosEspecialidad.DataValueField = "Legajo_Me";
            ddlMedicosEspecialidad.DataBind();
        }

        protected void btnGestionar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            DropDownList ddlOpciones = (DropDownList)row.FindControl("ddlOpciones");

            string idTurno = btn.CommandArgument;

            if (ddlOpciones != null)
            {
                string selectedValue = ddlOpciones.SelectedValue;

                if (selectedValue == "5") // Cancelar
                {
                    if (negocioTurno.CancelarTurnoGestion(idTurno))
                    {
                        CargarTurnos();
                        ShowBootstrapAlert("Turno eliminado.", "success");
                    }
                    else
                    {
                        CargarTurnos();
                        ShowBootstrapAlert("Error al cancelar el turno.", "danger");
                    }
                }
                else if (selectedValue == "3") // Reprogramar
                {
                    Turno turno = negocioTurno.getTurno(idTurno);

                    lblEspecialidad.Text = turno.getIdEspecialidad().ToString();

                    lblPaciente.Text = turno.getDNI_Paciente();

                    CargarDDLMedicosEspecialidad(turno.getIdEspecialidad());

                    CargarTurnos();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "showGestionarModal();", true);
                }
                else if (selectedValue == "0") // No se seleccionó ninguna opción
                {
                    // Mostrar mensaje de error
                    ShowBootstrapAlert("Por favor, seleccione una opción.", "warning");
                }
                ddlOpciones.SelectedValue = "0";
            }
        }

        private void ShowBootstrapAlert(string message, string alertType)
        {
            string alertHtml = $"<div class='alert alert-{alertType} alert-dismissible fade show' role='alert'>" +
                               $"{message}" +
                               "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button>" +
                               "</div>";

            alertContainer.InnerHtml = alertHtml;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CargarTurnos();
        }

        protected void gvTurnos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlOpciones = (DropDownList)e.Row.FindControl("ddlOpciones");
                if (ddlOpciones != null)
                {
                    ddlOpciones.Items.Add(new ListItem("Seleccionar", "0"));
                    ddlOpciones.Items.Add(new ListItem("Reprogramar", "3"));
                    ddlOpciones.Items.Add(new ListItem("Cancelar", "5"));
                }
            }
        }

        protected void dlHorario_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "SeleccionarHorario")
            {
                // Obtener el horario seleccionado del CommandArgument
                string horarioSeleccionado = e.CommandArgument.ToString();

                Session["horarioSeleccionado"] = horarioSeleccionado;
            }
        }
    }
}