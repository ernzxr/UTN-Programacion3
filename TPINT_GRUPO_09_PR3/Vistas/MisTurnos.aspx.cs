using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class MisTurnos : System.Web.UI.Page
    {
        NegocioTurno negocioTurno = new NegocioTurno();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if(Session["Legajo"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                CargarTurnos();
            }
        }

        private void CargarTurnos()
        {
            DataTable dt = negocioTurno.getTurnosMedico(Session["Legajo"].ToString());
            gvTurnos.DataSource = dt;
            gvTurnos.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblMensajeError.Text = "";

            string legajo = Session["Legajo"].ToString();
            string busqueda = txtBuscar.Text.Trim();

            if (!string.IsNullOrEmpty(busqueda))
            {
                DataTable dt = negocioTurno.BuscarTurnosPorMedico(legajo, busqueda);

                if (dt.Rows.Count > 0)
                {
                    Session["DatosFiltrados"] = dt;
                    gvTurnos.DataSource = dt;
                    gvTurnos.DataBind();
                    LimpiarCampos();
                }
                else
                {
                    lblMensajeError.Text = "No se encontraron resultados para la búsqueda.";
                    Limpiar_gvTurnos();
                }
            }
            else
            {
                lblMensajeError.Text = "Ingrese un texto para buscar.";
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            lblMensajeError.Text = "";

            // Validar datos ingresados
            if (string.IsNullOrWhiteSpace(txtDniPaciente.Text) || !DateTime.TryParse(txtDia.Text, out DateTime fechaSeleccionada))
            {
                lblMensajeError.Text = "Debe ingresar un DNI y una fecha válida.";
                return;
            }

            string dni = txtDniPaciente.Text.Trim();
            string legajo = Session["Legajo"].ToString();

            // Obtener los turnos filtrados
            DataTable dt = negocioTurno.ObtenerTurnosPorDniFecha(legajo, dni, fechaSeleccionada);

            if (dt.Rows.Count > 0)
            {
                Session["DatosFiltrados"] = dt;
                gvTurnos.DataSource = dt;
                gvTurnos.DataBind();
                LimpiarCampos();
            }
            else
            {
                lblMensajeError.Text = "No se encontraron turnos para el filtro aplicado.";
                Limpiar_gvTurnos();
            }
        }

        protected void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            Session["DatosFiltrados"] = null;
            CargarTurnos();
            LimpiarCampos();
        }

        public void LimpiarCampos()
        {
            txtBuscar.Text = "";
            txtDniPaciente.Text = "";
            txtDia.Text = "";
            lblMensajeError.Text = "";
        }

        public void Limpiar_gvTurnos()
        {
            gvTurnos.DataSource = null;
            gvTurnos.DataBind();
        }

        protected void gvTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTurnos.PageIndex = e.NewPageIndex;

            // Verificar si hay datos filtrados almacenados en Session
            if (Session["DatosFiltrados"] != null)
            {
                // Recuperar los datos filtrados
                DataTable dt = (DataTable)Session["DatosFiltrados"];

                // Recargar el GridView con los datos filtrados
                gvTurnos.DataSource = dt;
                gvTurnos.DataBind();
            }
            else
            {
                CargarTurnos();
            }
        }

        protected void gvTurnos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTurnos.EditIndex = e.NewEditIndex;
            CargarTurnos();
        }

        protected void gvTurnos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTurnos.EditIndex = -1;
            CargarTurnos();
        }

        protected void gvTurnos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                // Obtener la clave primaria
                string legajoMedico = Session["Legajo"].ToString();
                string dniPaciente = ((Label)gvTurnos.Rows[e.RowIndex].FindControl("lblDniEdit")).Text;
                DateTime fecha = DateTime.Parse(((Label)gvTurnos.Rows[e.RowIndex].FindControl("lblFechaEdit")).Text);
                TimeSpan hora = TimeSpan.Parse(((Label)gvTurnos.Rows[e.RowIndex].FindControl("lblHoraEdit")).Text);

                // Obtener valores de edición
                bool asistencia = ((CheckBox)gvTurnos.Rows[e.RowIndex].FindControl("cbAsistencia")).Checked;
                string observaciones = ((TextBox)gvTurnos.Rows[e.RowIndex].FindControl("txtObservaciones")).Text;

                // Crear objeto Turno
                Turno turno = new Turno();
                turno.setLegajo_Medico(legajoMedico);
                turno.setDni_Paciente(dniPaciente);
                turno.setFecha(fecha);
                turno.setHora(hora);
                turno.setAsistencia(asistencia);
                turno.setObservacion(observaciones);

                // Actualizar turno
                if (negocioTurno.ActualizarTurno(turno))
                {
                    lblMensajeError.Text = "Turno actualizado correctamente.";
                }
                else
                {
                    lblMensajeError.Text = "Error al actualizar el turno.";
                }

                // Salir del modo de edición
                gvTurnos.EditIndex = -1;
                CargarTurnos();
            }
            catch (Exception ex)
            {
                lblMensajeError.Text = "Error: " + ex.Message;
            }

        }
    }
}