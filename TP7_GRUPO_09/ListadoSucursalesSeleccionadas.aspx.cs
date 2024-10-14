using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP6_GRUPO_09.Utils;
using TP7_GRUPO_09.Utils;

namespace TP7_GRUPO_09
{
    public partial class ListadoSucursalesSeleccionadas : System.Web.UI.Page
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
            if (Session["sucursalSeleccionada"] != null)
            {
                DataTable sucursales = (DataTable)Session["sucursalSeleccionada"];
                grdSucursales.DataSource = sucursales;
                grdSucursales.DataBind();
            }
            else
            {
                // Manejar el caso donde no hay sucursales seleccionadas
                grdSucursales.DataSource = null;
                grdSucursales.DataBind();
            }
        }


            protected void grdSucursales_SelectedIndexChanged(object sender, EventArgs e)
            {

             }

        protected void grdSucursales_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;

            DataTable sucursales = (DataTable)Session["sucursalSeleccionada"];

            if (sucursales != null && index < sucursales.Rows.Count)
            {
                sucursales.Rows.RemoveAt(index);

                Session["sucusalSeleccionada"] = sucursales;
                grdSucursales.DataSource = sucursales;
                grdSucursales.DataBind();
            }

        }
    }
}