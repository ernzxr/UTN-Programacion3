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
    public partial class ListarTurnos : System.Web.UI.Page
    {
        NegocioTurno negocioTurno = new NegocioTurno();
        NegocioMedico negocioMedico = new NegocioMedico();
        NegocioPaciente negocioPaciente = new NegocioPaciente();
        //NegocioDetallesTurno negocioDetallesTurno = new NegocioDetallesTurno();
        //NegocioCiclosTurno negocioCiclosTurno = new NegocioCiclosTurno();

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
        }

        private void CargarTurnos()
        {
            DataTable dt = negocioTurno.getTurnos();
            gvTurnos.DataSource = dt;
            gvTurnos.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text.Trim();

            if (!string.IsNullOrEmpty(busqueda))
            {
                DataTable dt = negocioTurno.BuscarTurnos(busqueda);

                if (dt.Rows.Count > 0)
                {
                    Session["DatosFiltrados"] = dt;
                    gvTurnos.DataSource = dt;
                    gvTurnos.DataBind();
                    LimpiarCampos();
                }
                else
                {
                    Limpiar_gvTurnos();
                    lblMensajeError.Text = "No se encontraron resultados para la búsqueda ingresada.";
                }
            }
            else
            {
                lblMensajeError.Text = "Ingrese un valor para buscar.";
            }
        }

        protected void btnFiltrarLegajo_Click(object sender, EventArgs e)
        {
            if (negocioMedico.existeLegajo(txtLegajo.Text.Trim()))
            {
                if (negocioTurno.existeLegajo(txtLegajo.Text.Trim()))
                {
                    DataTable dt = negocioTurno.ObtenerTurnosPorLegajo(txtLegajo.Text.Trim());

                    if (dt.Rows.Count > 0)
                    {
                        Session["DatosFiltrados"] = dt;
                        gvTurnos.DataSource = dt;
                        gvTurnos.DataBind();
                        LimpiarCampos();
                    }
                }
                else
                {
                    lblMensajeError.Text = "El médico no tiene turnos asignados.";
                    Limpiar_gvTurnos();
                    txtLegajo.Text = "";
                }
            }
            else
            {
                lblMensajeError.Text = "No existe el legajo ingresado.";
                Limpiar_gvTurnos();
                txtLegajo.Text = "";
            }
        }

        protected void btnFiltrarDniPaciente_Click(object sender, EventArgs e)
        {
            string dni = Convert.ToString(txtDniPaciente.Text.Trim());

            if (negocioPaciente.existePacienteDni(dni))
            {
                DataTable dt = negocioTurno.ObtenerTurnosPorDni(dni);

                if (dt.Rows.Count > 0)
                {
                    // Almacenar en Session para mantener los datos
                    Session["DatosFiltrados"] = dt;
                    gvTurnos.DataSource = dt;
                    gvTurnos.DataBind();
                    txtDniPaciente.Text = "";
                    LimpiarCampos();
                }
                else
                {
                    lblMensajeError.Text = "El paciente no tiene turnos asignados.";
                    Limpiar_gvTurnos();
                    txtDniPaciente.Text = "";
                }

            }
            else
            {
                lblMensajeError.Text = "No existe el DNI del paciente ingresado.";
                Limpiar_gvTurnos();
                txtDniPaciente.Text = "";
            }
        }

        protected void btnFiltrarDia_Click(object sender, EventArgs e)
        {
            lblMensajeError.Text = "";
            // Validar si se ingresó una fecha válida
            if (DateTime.TryParse(txtDia.Text, out DateTime fechaSeleccionada))
            {
                // Obtener los turnos para la fecha seleccionada
                DataTable dt = negocioTurno.ObtenerTurnosPorFecha(fechaSeleccionada);

                if (dt.Rows.Count > 0)
                {
                    Session["DatosFiltrados"] = dt;

                    gvTurnos.DataSource = dt;
                    gvTurnos.DataBind();
                    txtDia.Text = "";
                }
                else
                {

                    lblMensajeError.Text = "No hay turnos asignados para la fecha seleccionada.";
                    Limpiar_gvTurnos();
                }
            }
            else
            {
                lblMensajeError.Text = "Ingrese una fecha válida.";
            }
        }

        protected void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            // Limpiar cualquier dato almacenado en Session
            Session["DatosFiltrados"] = null;
            CargarTurnos();
            LimpiarCampos();
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

        public void LimpiarCampos()
        {
            txtBuscar.Text = "";
            txtLegajo.Text = "";
            txtDniPaciente.Text = "";
            txtDia.Text = "";
            lblMensajeError.Text = "";
        }

        public void Limpiar_gvTurnos()
        {
            gvTurnos.DataSource = null;
            gvTurnos.DataBind();
        }

        protected void gvTurnos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string s_idTurno = ((Label)gvTurnos.Rows[e.RowIndex].FindControl("lblIdTurno")).Text;
            Session["IdTurno"] = s_idTurno;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "showDeleteModal", "showDeleteModal();", true);

        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            bool elimino = negocioTurno.CancelarTurno(Convert.ToInt32(Session["IdTurno"]));
            if (Session["DatosFiltrados"] == null)
            {
                CargarTurnos();
            }
            else
            {
                gvTurnos.DataSource = (DataTable)Session["DatosFiltrados"];
                gvTurnos.DataBind();
            }
        }
    }
}