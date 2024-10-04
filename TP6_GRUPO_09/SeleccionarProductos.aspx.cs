using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP6_GRUPO_09.Utils;

namespace TP6_GRUPO_09
{
    public partial class SeleccionarProductos : System.Web.UI.Page
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
            Conexion con = new Conexion();
            // Utilizar metodo de la clase gestion para obtener los productos
            string querie = "SELECT * FROM Productos";
            grdProductos.DataSource = con.ObtenerTablas(querie, "Productos");
            grdProductos.DataBind();
        }

        public DataTable CrearTabla()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdProducto", System.Type.GetType("System.Int32"));
            dt.Columns.Add("NombreProducto", System.Type.GetType("System.String"));
            dt.Columns.Add("IdProveedor", System.Type.GetType("System.String"));
            dt.Columns.Add("PrecioUnidad", System.Type.GetType("System.Decimal"));

            return dt;
        }

        public bool AgregarFila(DataTable tabla, int idProducto, string nombreProducto,
                                int idProveedor, decimal precioUnidad)
        {
            bool existe = false;
            foreach (DataRow r in tabla.Rows)
            {
                if ((Convert.ToInt32(r["IdProducto"])) == idProducto)
                {
                    existe = true;
                    break;
                }
            }

            // Agregar fila al DataTable si no existe
            if (!existe) return true;
            else return false;
        }

        protected void grdProductos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string idProducto = ((Label)grdProductos.Rows[e.NewSelectedIndex].FindControl("lblItIdProd")).Text;
            string nombre = ((Label)grdProductos.Rows[e.NewSelectedIndex].FindControl("lblItNombreProd")).Text;
            string idProveedor = ((Label)grdProductos.Rows[e.NewSelectedIndex].FindControl("lblItIdProv")).Text;
            string precio = ((Label)grdProductos.Rows[e.NewSelectedIndex].FindControl("lblItPrecioProd")).Text;

            Producto prod = new Producto();
            prod.IdProducto = Convert.ToInt32(idProducto);
            prod.NombreProducto = nombre;
            prod.IdProveedor = Convert.ToInt32(idProveedor);
            prod.PrecioUnidad = Convert.ToDecimal(precio);

            if (Session["ProductosSeleccionados"] == null)
            {
                Session["ProductosSeleccionados"] = CrearTabla();
                AgregarFila((DataTable)Session["ProductosSeleccionados"], Convert.ToInt32(idProducto), nombre, Convert.ToInt32(idProveedor), Convert.ToDecimal(precio));

                lblProductosAgregados.Text = "Productos Agregados: ";
                lblProductosAgregados.Text += nombre;
            }
            else if (AgregarFila((DataTable)Session["ProductosSeleccionados"], Convert.ToInt32(idProducto), nombre, Convert.ToInt32(idProveedor), Convert.ToDecimal(precio)))
            {
                lblProductosAgregados.Text += ", " + nombre;
            }
        }

        protected void grdProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProductos.PageIndex = e.NewPageIndex;
            CargarGridView();
        }
    }
}