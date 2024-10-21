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

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            NegocioSucursal negocioSucursal = new NegocioSucursal();

            if (int.TryParse(txtIDSucursal.Text, out int idSucursal))
            {
                bool eliminado = negocioSucursal.eliminarSucursal(idSucursal);
                if (eliminado)
                {
                    lblEliminarSucursal.Text = "La sucursal se elimino con éxito";

                }
                else
                {
                    lblEliminarSucursal.Text = " No se pudo eliminar la sucursal";

                }

            }
            else
            {
                lblEliminarSucursal.Text = "Por favor, ingrese un ID de sucursal válido";
            }
            txtIDSucursal.Text = string.Empty;

        }
    }
    
}