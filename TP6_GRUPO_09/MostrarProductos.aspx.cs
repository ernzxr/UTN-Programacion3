using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP6_GRUPO_09
{
    public partial class MostrarProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductosSeleccionados();
            }
        }

        private void CargarProductosSeleccionados()
        { 
            if (Session["ProductosSeleccionados"] != null)
            {
                DataTable dtProductosSeleccionados = (DataTable)Session["ProductosSeleccionados"];

                if (dtProductosSeleccionados.Rows.Count > 0)
                {
                    grdProductosSeleccionados.DataSource = dtProductosSeleccionados;
                    grdProductosSeleccionados.DataBind();
                }
                else
                {
                    lblMensaje.Text = "No hay productos seleccionados.";
                }
            }
            else
            {
                lblMensaje.Text = "No hay productos seleccionados.";
            }
        }
    }
}



