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
            NegocioSucursal negocioSucursal = new NegocioSucursal();
            DataTable dt = negocioSucursal.ObtenerSucursales();
            gvSucursales.DataSource = dt;
            gvSucursales.DataBind();
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            CargarSucursales();
        }
    }
}