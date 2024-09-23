using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP5
{
    public partial class ListarSucursal : System.Web.UI.Page
    {
        DML dml = new DML();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                CargarSucursales();
            }
        }

        private void CargarSucursales()
        {
            DataTable dt = dml.ObtenerSucursales();
            gvSucursales.DataSource = dt;
            gvSucursales.DataBind();
        }

        private void FiltrarSucursal()
        {
            DataTable dt = dml.BuscarSucursal(txtBuscarSucursal.Text);
            gvSucursales.DataSource = dt;
            gvSucursales.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarSucursal();
        }

        protected void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            CargarSucursales();
        }
    }
}