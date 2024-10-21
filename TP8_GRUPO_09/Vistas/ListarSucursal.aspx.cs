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
    public partial class ListarSucursal : System.Web.UI.Page
    {
        NegocioSucursal negocioSucursal = new NegocioSucursal();
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            rfvIdSucursal.ForeColor = System.Drawing.Color.Red;

            if (!IsPostBack)
            {
                CargarSucursales();
            }
        }
        private void CargarSucursales()
        {
            DataTable dt = negocioSucursal.ObtenerSucursales();
            gvSucursales.DataSource = dt;
            gvSucursales.DataBind();
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            CargarSucursales();
            txtIdSucursal.Text = "";
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            DataTable dt = negocioSucursal.ObtenerSucursalesFiltradas(Convert.ToInt32(txtIdSucursal.Text));
            gvSucursales.DataSource = dt;
            gvSucursales.DataBind();
            txtIdSucursal.Text = "";
        }
    }
}