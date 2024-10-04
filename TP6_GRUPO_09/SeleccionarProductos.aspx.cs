using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP6_GRUPO_09
{
    public partial class SeleccionarProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public DataTable CrearTabla()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdProducto", System.Type.GetType("System.Int32"));
            dt.Columns.Add("NombreProducto", System.Type.GetType("System.String"));
            dt.Columns.Add("CantidadPorUnidad", System.Type.GetType("System.String"));
            dt.Columns.Add("PrecioUnidad", System.Type.GetType("System.Decimal"));

            return dt;
        }

        public void AgregarFila(DataTable tabla, int IdProducto, string NombreProducto,
                                string CantidadPorUnidad, decimal PrecioUnidad)
        {
            //lblMensaje.Text = "";

            bool existe = false;
            foreach (DataRow r in tabla.Rows)
            {
                if ((Convert.ToInt32(r["IdProducto"])) == IdProducto)
                {
                    existe = true;
                    break;
                }
            }

            //Continuar...
        }
    }
}