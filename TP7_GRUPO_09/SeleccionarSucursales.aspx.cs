using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP7_GRUPO_09.Utils;

namespace TP7_GRUPO_09
{
    public partial class SeleccionarSucursales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarListView();
            }
        }

        protected void CargarListView()
        {
            GestionSucursal gestor = new GestionSucursal();
            lvSucursales.DataSource = gestor.ObtenerSucursales();
            lvSucursales.DataBind();
        }

        protected void btnSeleccionar_Command(object sender, CommandEventArgs e)
        {
            if(e.CommandName == "eventoSeleccionar")
            {
                // Trabajar con el Session
            }
        }

        protected void lvSucursales_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            // Se obtiene el DataPager
            DataPager pager = (DataPager)lvSucursales.FindControl("DataPager1");

            // Establece las nuevas propiedades de la página
            pager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            CargarListView();
        }
    }
}