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
            // Utilizar metodo de la clase gestion para obtener los productos
            string querie = "SELECT * FROM Productos";
            grdProductos.DataSource = con.ObtenerTablas(querie, "Productos");
            grdProductos.DataBind();
        }

            protected void grdProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProductos.PageIndex = e.NewPageIndex;
            CargarGridView();
        }

        protected void grdProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string idProducto = ((Label)grdProductos.Rows[e.RowIndex].FindControl("lblItIdProd")).Text;
            
            Producto prod = new Producto();
            prod.IdProducto = Convert.ToInt32(idProducto);

            // Eliminar el producto con los metodos de gestion

            CargarGridView();
        }

        protected void grdProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdProductos.EditIndex = e.NewEditIndex;
            CargarGridView();
        }

        protected void grdProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdProductos.EditIndex = -1;
            CargarGridView();
        }

        protected void grdProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string idProducto = ((Label)grdProductos.Rows[e.RowIndex].FindControl("lblEitIdProd")).Text;
            string nombre = ((TextBox)grdProductos.Rows[e.RowIndex].FindControl("txtEitNombreProd")).Text;
            string precio = ((TextBox)grdProductos.Rows[e.RowIndex].FindControl("txtEitPrecioProd")).Text;
            string cantUni = ((TextBox)grdProductos.Rows[e.RowIndex].FindControl("txtEitCantUniProd")).Text;

            Producto prod = new Producto();
            prod.IdProducto = Convert.ToInt32(idProducto);
            prod.NombreProducto = nombre;
            prod.CantidadPorUnidad = cantUni;
            prod.PrecioUnidad = Convert.ToDecimal(precio);

            // Editar el producto con los metodos de gestion

            grdProductos.EditIndex = -1;
            CargarGridView();
        }
    }
}