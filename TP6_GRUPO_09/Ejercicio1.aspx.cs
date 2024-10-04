using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP6_GRUPO_09.Utils;

namespace TP6_GRUPO_09
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarGridView();
            }
        }

        private void CargarGridView()
        {
            Conexion con = new Conexion();
            string querie = "SELECT IdProducto AS [Id Producto], NombreProducto AS [Nombre Producto], CantidadPorUnidad AS [Cantidad Por Unidad], PrecioUnidad AS [Precio Unidad] FROM Productos";
            grdProductos.DataSource = con.ObtenerTablas(querie, "Productos");
            grdProductos.DataBind();
        }

            protected void grdProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProductos.PageIndex = e.NewPageIndex;
            //cargarGridView();
        }
    }
}