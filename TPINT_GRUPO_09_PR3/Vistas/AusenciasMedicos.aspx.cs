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
    public partial class AusenciasMedicos : System.Web.UI.Page
    {
        NegocioTipoAusencia negocioTipoAusencia = new NegocioTipoAusencia();
        NegocioAusenciaMedico negocioAusenciaMedico = new NegocioAusenciaMedico();
        NegocioMedico negocioMedico = new NegocioMedico();
        AusenciaMedico aus = new AusenciaMedico();

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
                CargarAusencias();
                CargarTiposAusencias();
            }

            alertContainer.InnerHtml = "";
        }

        private void CargarAusencias()
        {
            DataTable dt = negocioAusenciaMedico.getAusencias();
            gvAusencias.DataSource = dt;
            gvAusencias.DataBind();
        }

        private void CargarTiposAusencias()
        {
            DataTable dt = negocioTipoAusencia.getTiposAusencias();
            ddlTipoAusencia.DataSource = dt;
            ddlTipoAusencia.DataTextField = "Descripcion_TAM";
            ddlTipoAusencia.DataValueField = "Id_Tipo_Ausencia_TAM";
            ddlTipoAusencia.DataBind();
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
            if (negocioMedico.existeLegajo(txtLegajo.Text))
            {

                // capturar los datos del formulario y asignarlos a la instancia de Sucursal
                aus.setLegajoMedico(int.Parse(txtLegajo.Text));
                aus.setTipoAusencia(int.Parse(ddlTipoAusencia.SelectedValue));
                aus.setFechaInicio(DateTime.Parse(txtFechaInicio.Text));
                aus.setFechaFin(DateTime.Parse(txtFechaFin.Text));

                // llamar al método AgregarSucursal y verificar el resultado

                bool agregado = negocioAusenciaMedico.AgregarAusencia(aus);

                if (agregado)
                {
                    CargarAusencias();
                }
                else
                {
                    CargarAusencias();
                }

                aus = new AusenciaMedico();
            }
            else
            {
                ShowBootstrapAlert("El legajo ingresado no existe.", "danger");
            }
        }

        protected void gvAusencias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAusencias.PageIndex = e.NewPageIndex;
            CargarTiposAusencias();
            CargarAusencias();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (negocioMedico.existeLegajo(txtFiltrarLegajo.Text))
            {
                DataTable dt = negocioAusenciaMedico.FiltrarAusencias(txtFiltrarLegajo.Text);
                gvAusencias.DataSource = dt;
                gvAusencias.DataBind();
            }
            else
            {
                ShowBootstrapAlert("El legajo que quiere filtrar no existe.", "danger");
            }
        }

        protected void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            CargarTiposAusencias();
            CargarAusencias();
        }
    }
}