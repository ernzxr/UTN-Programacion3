﻿using System;
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

        private void cargarSumaPrecios()
        {
            decimal totalPrecio = 0;

            foreach (GridViewRow fila in grdProductos.Rows)
            {
                Label lblPrecio = (Label)fila.FindControl("lblItPrecioProd");

                if (lblPrecio != null)
                {
                    decimal precio;
                    if (decimal.TryParse(lblPrecio.Text, out precio))
                    {
                        totalPrecio += precio;
                    }
                }

                if (grdProductos.FooterRow != null)
                {
                    Label lblTotal = (Label)grdProductos.FooterRow.FindControl("lblft_Total");
                    if (lblTotal != null)
                    {
                        lblTotal.Text = "Total: " + totalPrecio.ToString("F2");
                    }
                }
            }
        }

        private void CargarGridView()
        {
            GestionProducto gProductos = new GestionProducto();
            grdProductos.DataSource = gProductos.ObtenerTodosLosProductos();
            grdProductos.DataBind();

            cargarSumaPrecios();
        }

        protected void grdProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProductos.PageIndex = e.NewPageIndex;
            CargarGridView();
        }

        private bool ValidarEliminacionProducto(GridViewDeleteEventArgs e, string idProducto)
        {
            Producto producto = new Producto();
            producto.IdProducto = Convert.ToInt32(idProducto);
            GestionProducto gProductos = new GestionProducto();
            bool eliminado = gProductos.EliminarProducto(producto);

            return eliminado;
        }

        protected void grdProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            string idProducto = ((Label)grdProductos.Rows[e.RowIndex].FindControl("lblItIDProd")).Text;
            bool elimino = ValidarEliminacionProducto(e, idProducto);

            if(elimino)
            {
                lblMensaje.Text = $"El producto {idProducto} fue eliminado con exito";
                CargarGridView();
            }
            else
            {
                lblMensaje.Text = "El producto no pudo ser eliminado";
                return;
            }

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

            // validacion de precio
            if (!decimal.TryParse(precio, out precioUni) || precioUni <= 0)
            {
                lblMensaje.Text = "El precio debe ser un número positivo.";
                return; // salir del metodo si la validación falla
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