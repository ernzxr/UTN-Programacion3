using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace Vistas
{
    public partial class EliminarSucursal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            NegocioSucursal negocioSucursal = new NegocioSucursal();
            int idSucursal = Convert.ToInt32(txtIDSucursal.Text);

            if (negocioSucursal.existeId(idSucursal))
            {
                bool eliminado = negocioSucursal.eliminarSucursal(idSucursal);
                if (eliminado)
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Blue;
                    lblMensaje.Text = "La sucursal con el ID " + idSucursal + " se eliminó correctamente.";

                }
                else
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "No se pudo eliminar la sucursal.";
                }

            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Purple;
                lblMensaje.Text = "No existe ninguna sucursal con ese ID.";
            }

            txtIDSucursal.Text = "";

        }
    }
    
}