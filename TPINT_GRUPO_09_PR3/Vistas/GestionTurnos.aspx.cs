using Entidades;
using Negocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
        NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
        NegocioHorarioMedico negocioHorario = new NegocioHorarioMedico();
        NegocioAusenciaMedico negocioAusenciaMedico = new NegocioAusenciaMedico();
        NegocioPaciente negocioPaciente = new NegocioPaciente();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                CargarTurnos();
            }

            alertContainer.InnerHtml = "";
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

            ddlMedicosEspecialidad.Items.Insert(0, new ListItem("Seleccionar", "0"));
            ddlMedicosEspecialidad.Items[0].Attributes["disabled"] = "disabled";
            ddlMedicosEspecialidad.Items[0].Selected = true;
        }

        protected void btnGestionar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            DropDownList ddlOpciones = (DropDownList)row.FindControl("ddlOpciones");

            Site1 master = (Site1)this.Master;

            string idTurno = btn.CommandArgument;

            if (ddlOpciones != null)
            {
                string selectedValue = ddlOpciones.SelectedValue;

                if (selectedValue == "5") // Cancelar
                {
                    if (negocioTurno.CancelarTurnoGestion(idTurno))
                    {
                        CargarTurnos();
                        master.actualizarTurnosPendientes();
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

                    int idEspecialidad = turno.getIdEspecialidad();

                    lblPaciente.Text = "DNI del Paciente: " + turno.getDNI_Paciente();

                    lblEspecialidad.Text = "Especialidad: " + negocioEspecialidad.getDescripcionEspecialidad(idEspecialidad);

                    CargarDDLMedicosEspecialidad(idEspecialidad);

                    LimpiarDLHorario();

                    lblHorarioSeleccionado.Text = "";
                    txtDia.Text = "";

                    Session["idTurno"] = idTurno;
                    Session["DNI"] = turno.getDNI_Paciente();

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

        public void LimpiarDLHorario()
        {
            // Limpiar el DataList antes de procesar la nueva fecha
            dlHorario.DataSource = null;
            dlHorario.DataBind();
        }

        private void CargarHorariosDisponibles(string legajoMedico, DateTime fechaSeleccionada)
        {
            // Obtener día de la semana seleccionado
            int idDiaSemana = (int)fechaSeleccionada.DayOfWeek;

            // Obtener horarios de trabajo del médico para el día seleccionado
            DataTable horariosTrabajo = negocioHorario.ObtenerDiasLaborales(legajoMedico);

            // Verificar si se obtuvo el DataTable con las columnas esperadas
            if (horariosTrabajo.Columns.Contains("Hora_Inicio_HM") && horariosTrabajo.Columns.Contains("Hora_Fin_HM"))
            {
                DataRow[] horarioFiltrado = horariosTrabajo.Select($"Id_Dia_Semana_HM = {idDiaSemana}");

                // Obtener hora de inicio y fin del horario laboral del médico
                TimeSpan horaInicio = (TimeSpan)horarioFiltrado[0]["Hora_Inicio_HM"];
                TimeSpan horaFin = (TimeSpan)horarioFiltrado[0]["Hora_Fin_HM"];

                // Obtener los horarios ya asignados para este médico en la fecha seleccionada
                DataTable horariosAsignados = negocioTurno.ObtenerHorariosAsignados(legajoMedico, fechaSeleccionada);

                // Crear lista de horarios asignados para facilitar la búsqueda
                HashSet<TimeSpan> horariosAsignadosSet = new HashSet<TimeSpan>();
                foreach (DataRow row in horariosAsignados.Rows)
                {
                    horariosAsignadosSet.Add((TimeSpan)row["Hora_Tu"]);
                }

                // Crear DataTable para horarios disponibles
                DataTable dtHorarios = new DataTable();
                dtHorarios.Columns.Add("Horario", typeof(string));

                // Generar botones por cada hora disponible, excluyendo los horarios ya asignados
                for (TimeSpan hora = horaInicio; hora < horaFin; hora = hora.Add(TimeSpan.FromHours(1)))
                {
                    if (!horariosAsignadosSet.Contains(hora)) // Verificar si el horario ya está asignado
                    {
                        DataRow fila = dtHorarios.NewRow();
                        fila["Horario"] = hora.ToString(@"hh\:mm");
                        dtHorarios.Rows.Add(fila);
                    }
                }

                // Verificar si hay horarios disponibles
                if (dtHorarios.Rows.Count == 0)
                {
                    ShowBootstrapAlert("No hay turnos disponibles.", "warning");
                    return;
                }

                // Cargar DataList con los horarios disponibles
                dlHorario.DataSource = dtHorarios;
                dlHorario.DataBind();
                UpdatePanelHorarios.Update();
            }
            else
            {
                ShowBootstrapAlert("Error al obtener los horarios.", "danger");
            }

        }

        private void ShowBootstrapAlert(string message, string alertType)
        {
            string alertHtml = $"<div class='alert alert-{alertType} alert-dismissible fade show' role='alert'>" +
                               $"{message}" +
                               "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button>" +
                               "</div>";

            alertContainer.InnerHtml = alertHtml;


            // Registrar el script para eliminar el contenido del contenedor cuando se cierre el alert
            ScriptManager.RegisterStartupScript(this, this.GetType(), "RemoveAlert", "removeAlertOnClose();", true);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Session["horarioSeleccionado"] == null)
            {
                ShowBootstrapAlert("Debe seleccionar un horario.", "danger");
                return;
            }

            if (Session["DNI"] == null)
            {
                ShowBootstrapAlert("Paciente no encontrado.", "danger");
                return;
            }

            if (Session["idTurno"] == null)
            {
                ShowBootstrapAlert("Error al obtener el turno.", "danger");
                return;
            }

            if (ddlMedicosEspecialidad.SelectedValue == "0")
            {
                ShowBootstrapAlert("Debe seleccionar un médico.", "danger");
                return;
            }

            Site1 master = (Site1)this.Master;

            string dni = Session["DNI"].ToString();

            if (negocioPaciente.existePacienteDni(dni))
            {
                string formatoFecha = "dd/MM/yyyy";
                DateTime fechaSeleccionada = DateTime.ParseExact(txtDia.Text, formatoFecha, System.Globalization.CultureInfo.InvariantCulture);

                // Obtener el horario seleccionado desde Session
                string horarioSeleccionado = Session["horarioSeleccionado"].ToString();

                TimeSpan horaSeleccionada = TimeSpan.Parse(horarioSeleccionado);

                Turno turno = new Turno();

                turno.setLegajo_Medico(ddlMedicosEspecialidad.SelectedValue);
                turno.setFecha(fechaSeleccionada);
                turno.setHora(horaSeleccionada);
                turno.setDni_Paciente(dni);
                turno.setIdLocalidadPaciente(negocioPaciente.ObtenerLocalidadPorDNI(dni));
                turno.setAsistencia(false);
                turno.setIdNacionalidad(negocioPaciente.ObtenerNacionalidadPorDNI(dni));

                bool turnoAgregado = negocioTurno.AgregarTurno(turno);

                if (turnoAgregado)
                {
                    negocioTurno.ReprogramarTurnoGestion(Session["idTurno"].ToString());
                    CargarTurnos();
                    master.actualizarTurnosPendientes();
                    ShowBootstrapAlert("Turno reprogramado exitosamente!", "success");
                }
                else
                {
                    ShowBootstrapAlert("No se pudo reprogramar el turno.", "danger");
                }

                Session["horarioSeleccionado"] = null;
                Session["idTurno"] = null;
                Session["DNI"] = null;
            }
            else
            {
                Session["horarioSeleccionado"] = null;
                Session["idTurno"] = null;
                Session["DNI"] = null;
                ShowBootstrapAlert("Paciente no encontrado.", "danger");
            }

            CargarTurnos();
            master.actualizarTurnosPendientes();
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

                lblHorarioSeleccionado.Text = $"Horario seleccionado: {horarioSeleccionado}";
            }
        }

        protected void ddlMedicosEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string legajoMedico = ddlMedicosEspecialidad.SelectedValue;

            // Verificar si es un día de ausencia
            DataTable fechasAusencias = negocioAusenciaMedico.ObtenerFechasAusencias(legajoMedico);
            List<DateTime> fechasDeAusencia = new List<DateTime>();

            foreach (DataRow row in fechasAusencias.Rows)
            {
                DateTime fechaInicio = Convert.ToDateTime(row["Fecha_Inicio_AM"]);
                DateTime fechaFin = Convert.ToDateTime(row["Fecha_Fin_AM"]);


                while (fechaInicio <= fechaFin)
                {
                    fechasDeAusencia.Add(fechaInicio);
                    fechaInicio = fechaInicio.AddDays(1); // Incrementar la fecha por un día
                }
            }

            List<string> fechasExcepcionalesFormateadas = fechasDeAusencia
            .Select(fecha => fecha.ToString("yyyy-MM-dd"))
            .ToList();

            // Pasar las fechas de ausencia al frontend en formato JSON
            string fechasAusenciasJson = JsonConvert.SerializeObject(fechasExcepcionalesFormateadas);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "FecAusencias", $"cargarAusencias({fechasAusenciasJson});", true);

            // Validar si es un día laborable
            DataTable diasLaborales = negocioHorario.ObtenerDiasLaborales(legajoMedico);
            List<bool> diasLaboralesLista = new List<bool>();

            for (int i = 0; i < 7; i++)
            {
                diasLaboralesLista.Add(false);
            }

            foreach (DataRow row in diasLaborales.Rows)
            {
                switch (row["DescripcionDia"].ToString())
                {
                    case "Domingo":
                        diasLaboralesLista[0] = true; // Si es Domingo, ponemos 'true' en el índice 0
                        break;
                    case "Lunes":
                        diasLaboralesLista[1] = true; // Si es Lunes, ponemos 'true' en el índice 1
                        break;
                    case "Martes":
                        diasLaboralesLista[2] = true; // Si es Martes, ponemos 'true' en el índice 2
                        break;
                    case "Miercoles":
                        diasLaboralesLista[3] = true; // Si es Miércoles, ponemos 'true' en el índice 3
                        break;
                    case "Jueves":
                        diasLaboralesLista[4] = true; // Si es Jueves, ponemos 'true' en el índice 4
                        break;
                    case "Viernes":
                        diasLaboralesLista[5] = true; // Si es Viernes, ponemos 'true' en el índice 5
                        break;
                    case "Sabado":
                        diasLaboralesLista[6] = true; // Si es Sábado, ponemos 'true' en el índice 6
                        break;
                }
            }

            string diasLaboralesJson = JsonConvert.SerializeObject(diasLaboralesLista);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "DiasLaborales", $"cargarDatePicker({diasLaboralesJson});", true);
        }

        protected void txtDia_TextChanged(object sender, EventArgs e)
        {
            if (txtDia.Text != "" && ddlMedicosEspecialidad.SelectedValue != "-1")
            {
                string formatoFecha = "dd/MM/yyyy";
                DateTime fechaSeleccionada = DateTime.ParseExact(txtDia.Text, formatoFecha, System.Globalization.CultureInfo.InvariantCulture);
                CargarHorariosDisponibles(ddlMedicosEspecialidad.SelectedValue, fechaSeleccionada);
            }
        }
    }
}