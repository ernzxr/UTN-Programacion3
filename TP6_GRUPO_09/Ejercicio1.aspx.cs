using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            if (!IsPostBack)
            {
                CargarGridView();
            }
        }

        private void CargarGridView()
        {
            GestionProducto gProductos = new GestionProducto();
            grdProductos.DataSource = gProductos.ObtenerTodosLosProductos();
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
            Producto producto = new Producto();
            producto.IdProducto = Convert.ToInt32(idProducto);
            GestionProducto gProductos = new GestionProducto();
            bool eliminado = gProductos.EliminarProducto(producto);

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

            // variables para validar
            decimal precioUni;
            int cantidad;

            // validacion de precio
            if (!decimal.TryParse(precio, out precioUni) || precioUni <= 0)
            {
                lblMensaje.Text = "El precio debe ser un número positivo.";
                return; // salir del metodo si la validación falla
            }

            // validacion de cantidad
            if (!int.TryParse(cantUni, out cantidad) || cantidad <= 0)
            {
                lblMensaje.Text = "La cantidad debe ser un número entero positivo.";
                return; // salir del metodo si la validacion falla
            }

            // Editar el producto con los metodos de gestion
            Producto prod = new Producto();
            prod.IdProducto = Convert.ToInt32(idProducto);
            prod.NombreProducto = nombre;
            prod.CantidadPorUnidad = cantUni;
            prod.PrecioUnidad = Convert.ToDecimal(precio);
            GestionProducto glProductos = new GestionProducto();
            glProductos.ActualizarProducto(prod);

            grdProductos.EditIndex = -1;
            CargarGridView();
        }
        protected void grdProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}