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
    public partial class Historial : System.Web.UI.Page
    {

        NegocioTurno negocioTurno = new NegocioTurno();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (Session["Legajo"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                CargarFiltros();
                CargarTurnos();
            }
        }

        private void CargarFiltros()
        {
            ddlFiltros.Items.Add(new ListItem("Quitar Filtros", "0"));
            ddlFiltros.Items.Add(new ListItem("Reprogramados", "3"));
            ddlFiltros.Items.Add(new ListItem("Terminados", "4"));
            ddlFiltros.Items.Add(new ListItem("Cancelados", "5"));
        }

        private void CargarTurnos()
        {
            DataTable dt = negocioTurno.getTurnosMedicoTodos(Session["Legajo"].ToString());
            gvTurnos.DataSource = dt;
            gvTurnos.DataBind();
        }

        private void FiltrarTurnos(int filtro)
        {
            DataTable dt = negocioTurno.getTurnosMedicoFiltrados(Session["Legajo"].ToString(), filtro);
            gvTurnos.DataSource = dt;
            gvTurnos.DataBind();
        }

        protected void btnVerTodos_Click(object sender, EventArgs e)
        {
            CargarTurnos();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (ddlFiltros.SelectedIndex == 0) {
                CargarTurnos();
            }
            else
            {
                FiltrarTurnos(Convert.ToInt32(ddlFiltros.SelectedValue));
            }
        }
    }
}