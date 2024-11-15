using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using Entidades;

namespace Vistas
{
    public partial class AsignarTurno : System.Web.UI.Page
    {
        NegocioEspecialidad negEspecialidad = new NegocioEspecialidad();
        NegocioMedico negMedico = new NegocioMedico();
        NegocioHorarioMedico negocioHorario = new NegocioHorarioMedico();
        NegocioDiaSemana negocioDiaSemana = new NegocioDiaSemana();
        NegocioAusenciaMedico negocioAusenciaMedico = new NegocioAusenciaMedico();
        NegocioPaciente negocioPaciente = new NegocioPaciente();
        NegocioTurno negocioTurno = new NegocioTurno();
        Turno turno = new Turno();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                CargarEspecialidades();
            }
        }

        private void CargarEspecialidades()
        {
            DataTable dt = negEspecialidad.getTablaEspecialidad();
            ddlEspecialidades.DataSource = dt;
            ddlEspecialidades.DataTextField = "Descripcion_Es";
            ddlEspecialidades.DataValueField = "Id_Especialidad_Es";
            ddlEspecialidades.DataBind();

            ddlEspecialidades.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
            ddlEspecialidades.Items[0].Attributes["disabled"] = "disabled";
            ddlEspecialidades.Items[0].Selected = true;

            ddlProfesionales.Items.Clear();
            ddlProfesionales.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
            ddlProfesionales.Items[0].Attributes["disabled"] = "disabled";
            ddlProfesionales.Items[0].Selected = true;
        }

        protected void EspecialidadSeleccionada(object sender, EventArgs e)
        {
            int especialidadId = Convert.ToInt32(ddlEspecialidades.SelectedValue);
            DataTable dt = negMedico.getTablaMedicoSegunEspecialidad(especialidadId);

            ddlProfesionales.Items.Clear();

            dt.Columns.Add("NombreCompleto", typeof(string), "Nombre_Me + ' ' + Apellido_Me");
            int autoIncrementValue = 1;

            foreach (DataRow row in dt.Rows)
            {
                string nombreCompleto = row["NombreCompleto"].ToString();

                // Agregar el ítem al DropDownList con value autoincremental
                ddlProfesionales.Items.Add(new ListItem(nombreCompleto, autoIncrementValue.ToString()));
                autoIncrementValue++; // Incrementar el valor para el siguiente ítem
            }

            ddlProfesionales.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
            ddlProfesionales.Items[0].Attributes["disabled"] = "disabled";
            ddlProfesionales.Items[0].Selected = true;
        }

        protected void txtDia_TextChanged(object sender, EventArgs e)
        {
            lblMensajeError.Text = "";
            lblMensajeError2.Text = "";

            // Limpiar el DataList antes de procesar la nueva fecha
            dlHorario.DataSource = null;
            dlHorario.DataBind();

            // Obtener el nombre completo del médico seleccionado
            string nombreCompleto = ddlProfesionales.SelectedItem.Text;
            if (string.IsNullOrEmpty(nombreCompleto))
            {
                lblMensajeError.Text = "Seleccione un médico.";
                return;
            }

            // Obtener el legajo del médico usando el nombre completo
            string legajoMedico = negMedico.ObtenerLegajoPorNombreCompleto(nombreCompleto);
            if (string.IsNullOrEmpty(legajoMedico))
            {
                lblMensajeError.Text = "No se encontró el legajo del médico.";
                return;
            }

            // Validación de la fecha seleccionada
            if (!DateTime.TryParse(txtDia.Text, out DateTime fechaSeleccionada))
            {
                lblMensajeError.Text = "Seleccione una fecha válida.";
                txtDia.Text = "";
                return;
            }

            // Obtener día de la semana
            int idDiaSemana = (int)fechaSeleccionada.DayOfWeek;

            // Validar si es un día laborable
            DataTable diasLaborales = negocioHorario.ObtenerDiasLaborales(legajoMedico);
            bool esDiaLaborable = false;

            foreach (DataRow row in diasLaborales.Rows)
            {
                if (idDiaSemana == Convert.ToInt32(row["Id_Dia_Semana_HM"]))
                {
                    esDiaLaborable = true;
                    break;
                }
            }

            if (!esDiaLaborable)
            {
                lblMensajeError.Text = "El médico no trabaja en el día seleccionado.";
                txtDia.Text = "";
                return;
            }

            // Verificar si es un día de ausencia
            DataTable fechasAusencias = negocioAusenciaMedico.ObtenerFechasAusencias(legajoMedico);
            foreach (DataRow row in fechasAusencias.Rows)
            {
                DateTime fechaInicio = Convert.ToDateTime(row["Fecha_Inicio_AM"]);
                DateTime fechaFin = Convert.ToDateTime(row["Fecha_Fin_AM"]);
                if (fechaSeleccionada >= fechaInicio && fechaSeleccionada <= fechaFin)
                {
                    lblMensajeError.Text = "El médico está ausente en la fecha seleccionada.";
                    txtDia.Text = "";
                    return;
                }
            }

            // Validar si todos los turnos están completos
            DataTable fechasTurnosCompletos = negocioHorario.ObtenerFechasConTurnosCompletos(legajoMedico);
            foreach (DataRow row in fechasTurnosCompletos.Rows)
            {
                if (fechaSeleccionada == Convert.ToDateTime(row["Fecha_Tu"]))
                {
                    lblMensajeError.Text = "No hay turnos disponibles para esta fecha.";
                    txtDia.Text = "";
                    return;
                }
            }

            // Cargar los horarios disponibles para la fecha seleccionada
            CargarHorariosDisponibles(legajoMedico, fechaSeleccionada);
        }


        private void CargarHorariosDisponibles(string legajoMedico, DateTime fechaSeleccionada)
        {
            lblMensajeError2.Text = "";

            // Obtener día de la semana seleccionado
            int idDiaSemana = (int)fechaSeleccionada.DayOfWeek;

            // Obtener horarios de trabajo del médico para el día seleccionado
            DataTable horariosTrabajo = negocioHorario.ObtenerDiasLaborales(legajoMedico);

            // Verificar si se obtuvo el DataTable con las columnas esperadas
            if (horariosTrabajo.Columns.Contains("Hora_Inicio_HM") && horariosTrabajo.Columns.Contains("Hora_Fin_HM"))
            {
                DataRow[] horarioFiltrado = horariosTrabajo.Select($"Id_Dia_Semana_HM = {idDiaSemana}");

                if (horarioFiltrado.Length == 0)
                {
                    lblMensajeError.Text = "El médico no trabaja en el día seleccionado.";
                    dlHorario.DataSource = null;
                    dlHorario.DataBind();
                    return;
                }

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
                    lblMensajeError.Text = "No hay horarios disponibles para el día seleccionado.";
                    dlHorario.DataSource = null;
                    dlHorario.DataBind();
                    return;
                }

                // Cargar DataList con los horarios disponibles
                dlHorario.DataSource = dtHorarios;
                dlHorario.DataBind();
            }
            else
            {
                lblMensajeError2.Text = "Error al obtener los horarios de trabajo del médico.";
                dlHorario.DataSource = null;
                dlHorario.DataBind();
            }

        }

        protected void dlHorario_ItemCommand(object source, DataListCommandEventArgs e)
        {
            //Verificar si el comando es "SeleccionarHorario"
            if (e.CommandName == "SeleccionarHorario")
            {
                // Obtener el horario seleccionado del CommandArgument
                string horarioSeleccionado = e.CommandArgument.ToString();

                Session["horarioSeleccionado"] = horarioSeleccionado;

                // Mostrar el horario seleccionado en el lblMensajeError como ejemplo
                lblMensajeError2.Text = $"Horario seleccionado: {horarioSeleccionado}";
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";

            // Obtener los datos ingresados en el formulario
            string nombreCompleto = ddlProfesionales.SelectedItem.Text;
            string legajoMedico = negMedico.ObtenerLegajoPorNombreCompleto(nombreCompleto);

            DateTime fechaSeleccionada = DateTime.Parse(txtDia.Text);

            // Obtener el horario seleccionado desde Session
            string horarioSeleccionado = Session["horarioSeleccionado"].ToString();

            TimeSpan horaSeleccionada = TimeSpan.Parse(horarioSeleccionado);

            string dni = Convert.ToString(txtDniPaciente.Text);

            turno.setLegajo_Medico(legajoMedico);
            turno.setFecha(fechaSeleccionada);
            turno.setHora(horaSeleccionada);
            turno.setDni_Paciente(txtDniPaciente.Text);
            turno.setIdLocalidadPaciente(negocioPaciente.ObtenerLocalidadPorDNI(dni));
            turno.setAsistencia(true);
            turno.setIdNacionalidad(negocioPaciente.ObtenerNacionalidadPorDNI(dni));

            bool turnoAgregado = negocioTurno.AgregarTurno(turno);

            if (turnoAgregado)
            {
                lblMensaje.Text = "El turno fue asignado correctamente";
            }
            else
            {
                lblMensaje.Text = "Error al asignar turno";
            }

            Session["horarioSeleccionado"] = null;
        }
    }
    
}