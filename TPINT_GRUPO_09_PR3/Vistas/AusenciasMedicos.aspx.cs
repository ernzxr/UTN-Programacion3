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
        AusenciaMedico aus = new AusenciaMedico();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            CargarTiposAusencias();

            if (!IsPostBack)
            {
                CargarAusencias();
            }
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

            ddlTipoAusencia.Items.Insert(0, new ListItem("Elegir una opción", "-1"));
            ddlTipoAusencia.Items[0].Attributes["disabled"] = "disabled";
            ddlTipoAusencia.Items[0].Selected = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // capturar los datos del formulario y asignarlos a la instancia de Sucursal
            aus.setLegajoMedico(int.Parse(txtLegajo.Text));
            aus.setTipoAusencia(int.Parse(ddlTipoAusencia.Text));
            aus.setFechaInicio(DateTime.Parse(txtFechaInicio.Text));
            aus.setFechaFin(DateTime.Parse(txtFechaFin.Text));

            // llamar al método AgregarSucursal y verificar el resultado

            bool agregado = negocioAusenciaMedico.AgregarAusencia(aus);

            if (agregado)
            {
                txtLegajo.Text = "OK";
                CargarTiposAusencias();
                CargarAusencias();
            }
            else
            {
                txtLegajo.Text = "FAIL";
            }

            aus = new AusenciaMedico();
        }

        protected void gvAusencias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAusencias.PageIndex = e.NewPageIndex;
            CargarTiposAusencias();
            CargarAusencias();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            DataTable dt = negocioAusenciaMedico.FiltrarAusencias(txtFiltrarLegajo.Text);
            gvAusencias.DataSource = dt;
            gvAusencias.DataBind();
        }

        protected void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            CargarTiposAusencias();
            CargarAusencias();
        }
    }
}