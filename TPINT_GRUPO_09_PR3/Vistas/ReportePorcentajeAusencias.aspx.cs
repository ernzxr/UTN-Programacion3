using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class ReportePorcentajeAusencias : System.Web.UI.Page
    {
        NegocioTurno negocioTurno = new NegocioTurno();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
        }
        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = DateTime.Parse(txtInicio.Text);
            DateTime fechaFin = DateTime.Parse(txtFin.Text);

           
            CargarDatos(fechaInicio, fechaFin);
        }
        private void CargarDatos(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable turnos = negocioTurno.ObtenerTurnosPorFechas(fechaInicio, fechaFin);
            // Verificar si se encontraron turnos
            if (turnos.Rows.Count > 0)
            {
                // Asignar los datos al GridView
                gvTurnos.DataSource = turnos;
                gvTurnos.DataBind();

                // Contar la cantidad de turnos ausentes
                int turnosAusentes = 0;
                foreach (DataRow row in turnos.Rows)
                {
                    // Verificar si el turno no fue asistido (Asistencia_Tu = 0)
                    if (Convert.ToBoolean(row["Asistencia_Tu"]) == false) // Asistencia 0 significa ausente
                    {
                        turnosAusentes++;
                    }
                }

                // Calcular el porcentaje de ausencias
                decimal porcentajeAusencias = turnos.Rows.Count > 0 ? (decimal)turnosAusentes / turnos.Rows.Count * 100 : 0;

                // Mostrar los resultados en los Labels
                lblTotalTurnos.Text = $"Total de turnos: {turnos.Rows.Count}";
                lblTurnosAusentes.Text = $"Turnos ausentes: {turnosAusentes}";
                lblPorcentaje.Text = $"Porcentaje de ausencias: {porcentajeAusencias:F2}%";

                lblTotalTurnos.Font.Bold = true;
                lblTotalTurnos.ForeColor = System.Drawing.Color.Black;

                lblTurnosAusentes.Font.Bold = true;
                lblTurnosAusentes.ForeColor = System.Drawing.Color.Red;

                lblPorcentaje.Font.Bold = true;
                lblPorcentaje.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                // Mostrar mensaje si no se encontraron turnos
                gvTurnos.EmptyDataText = "No se encontraron turnos en este rango de fechas.";
                gvTurnos.DataBind();

                // También mostrar un mensaje en los labels
                lblTotalTurnos.Text = "No se encontraron turnos.";
                lblTurnosAusentes.Text = "No se encontraron turnos.";
                lblPorcentaje.Text = "No se puede calcular el porcentaje.";
            }

        }
        protected void gvTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTurnos.PageIndex = e.NewPageIndex;

            DateTime fechaInicio = DateTime.Parse(txtInicio.Text);
            DateTime fechaFin = DateTime.Parse(txtFin.Text);
            CargarDatos(fechaInicio, fechaFin);
        }



    }
}