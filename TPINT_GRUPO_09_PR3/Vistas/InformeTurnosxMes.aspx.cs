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
    public partial class InformeTurnosxMes : System.Web.UI.Page
    {
       NegocioTurno  negocioTurno = new NegocioTurno();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            if (IsPostBack == false)
            {
                CargarAnios();
                CargarMeses();
            }
        }

        public void CargarAnios()
        {
            DataTable aniosTable = negocioTurno.ObtenerAniosDeTurnos();
            if (aniosTable.Rows.Count > 0)
            {
                ddlAnio.DataSource = aniosTable;
                ddlAnio.DataTextField = "Anio"; 
                ddlAnio.DataValueField = "Anio"; 
                ddlAnio.DataBind();
                ddlAnio.Items.Insert(0, new ListItem("Seleccionar año...", "0"));
            }
            else
            {
                ddlAnio.Items.Clear();
                ddlAnio.Items.Add(new ListItem("No hay años disponibles", "0"));
            }


        }
        public void CargarMeses()
        {
            DataTable MesesTable = negocioTurno.ObtenerMesesDeTurnos();
            if (MesesTable.Rows.Count > 0)
            {
                ddlMes.DataSource = MesesTable;
                ddlMes.DataTextField = "NombreMes";
                ddlMes.DataValueField = "Mes";
                ddlMes.DataBind();
                ddlMes.Items.Insert(0, new ListItem("Seleccionar mes...", "0"));
            }
            else
            {
                ddlMes.Items.Clear();
                ddlMes.Items.Add(new ListItem("No hay meses disponibles", "0"));
            }
        }

        public void LimpiarCampos()
        {
            ddlAnio.SelectedValue = "0";
            ddlMes.SelectedValue = "0";
        }

        protected void btnMostar_Click(object sender, EventArgs e)
        {
           
                int anio = Convert.ToInt32(ddlAnio.SelectedValue);
                int mes = Convert.ToInt32(ddlMes.SelectedValue);
                int cantidadTurnos = negocioTurno.ReporteCantidadTurnosPorMesYAnio(anio, mes);

                if (cantidadTurnos > 0)
                {
                    lblInforme.Text = $"En {ddlMes.SelectedItem.Text} de {anio} hubo {cantidadTurnos} turnos.";
                    lblInforme.ForeColor = System.Drawing.Color.Black;
                }

            
        }
    }
}