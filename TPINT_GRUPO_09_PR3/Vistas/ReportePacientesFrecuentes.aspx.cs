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
    public partial class ReportePacientesFrecuentes : System.Web.UI.Page
    {
        NegocioEspecialidad nege = new NegocioEspecialidad();
        NegocioPaciente negp = new NegocioPaciente();
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (IsPostBack == false)
            {
                CargarEspecialidad();
            }
        }

        public void CargarEspecialidad()
        {
            DataTable especialidades = nege.getTablaEspecialidad();
            ddlEspecialidad.DataSource = especialidades;
            ddlEspecialidad.DataTextField = "Descripcion_Es";
            ddlEspecialidad.DataValueField = "Id_Especialidad_Es";
            ddlEspecialidad.DataBind();

            ddlEspecialidad.Items.Insert(0, new ListItem("Seleccionar...", "0"));

        }

        public void LimpiarCampos()
        {
            ddlEspecialidad.SelectedValue = "0";
            txtFechaInicio.Text = "";
            txtFechaFin.Text = "";
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int ddl = Convert.ToInt32(ddlEspecialidad.SelectedValue);
            DateTime fi = Convert.ToDateTime(txtFechaInicio.Text);
            DateTime ff = Convert.ToDateTime(txtFechaFin.Text);


            DataTable reporte = negp.ReportePacientesConMasTurnos(ddl, fi, ff);
            if (reporte.Rows.Count == 0)
            {
                lblInformeEspecialidad.ForeColor = System.Drawing.Color.Red;
                lblInformeEspecialidad.Text = "No asistió ningún paciente entre las fechas " + txtFechaInicio.Text + " y " + txtFechaFin.Text + " para la especialidad " + ddlEspecialidad.SelectedItem.Text;
                gvPacientesConMasTurnos.DataSource = null;
                gvPacientesConMasTurnos.DataBind();
            }
            else
            {
                lblInformeEspecialidad.Text = ddlEspecialidad.SelectedItem.Text;
                gvPacientesConMasTurnos.DataSource = reporte;
                gvPacientesConMasTurnos.DataBind();
            }

            LimpiarCampos();
        }
    }
}