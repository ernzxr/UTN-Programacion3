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
        private void ActualizarLabelProductosSeleccionados()
        {
            lblProductosAgregados.Text = "Productos Agregados: ";

            if (Session["ProductosSeleccionados"] != null)
            {
                DataTable dt = (DataTable)Session["ProductosSeleccionados"];
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Rows.IndexOf(dr) == 0)
                    {
                        lblProductosAgregados.Text += dr["NombreProducto"].ToString();
                    }
                    else
                    {
                        lblProductosAgregados.Text += ", " + dr["NombreProducto"].ToString();
                    }
                }
            }
        }

        private void CargarLabelProductosSeleccionados()
        {
            if (Session["ProductosSeleccionados"] != null)
            {
                DataTable dt = (DataTable)Session["ProductosSeleccionados"];

                lblProductosAgregados.Text = "Productos Agregados: ";

                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Rows.IndexOf(dr) == 0)
                    {
                        lblProductosAgregados.Text += dr["NombreProducto"].ToString();
                    }
                    else
                    {
                        lblProductosAgregados.Text += ", " + dr["NombreProducto"].ToString();
                    }

                }
            }
        }

        private void CargarGridView()
        {
            GestionProducto gProductos = new GestionProducto();
            grdProductos.DataSource = gProductos.ObtenerTodosLosProductos();
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

        public bool AgregarFila(DataTable tabla, int idProducto)
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

        private Producto CargarDatosProducto(GridViewSelectEventArgs e)
        {
            string idProducto = ((Label)grdProductos.Rows[e.NewSelectedIndex].FindControl("lblItIdProd")).Text;
            string nombre = ((Label)grdProductos.Rows[e.NewSelectedIndex].FindControl("lblItNombreProd")).Text;
            string idProveedor = ((Label)grdProductos.Rows[e.NewSelectedIndex].FindControl("lblItIdProv")).Text;
            string precio = ((Label)grdProductos.Rows[e.NewSelectedIndex].FindControl("lblItPrecioProd")).Text;

            Producto prod = new Producto
            {
                IdProducto = Convert.ToInt32(idProducto),
                NombreProducto = nombre,
                IdProveedor = Convert.ToInt32(idProveedor),
                PrecioUnidad = Convert.ToDecimal(precio)
            };

            return prod;
        }

        private DataRow CargarDataRow(Producto prod, DataTable dt)
        {
            DataRow row = dt.NewRow();
            row["IdProducto"] = prod.IdProducto;
            row["NombreProducto"] = prod.NombreProducto;
            row["IdProveedor"] = prod.IdProveedor;
            row["PrecioUnidad"] = prod.PrecioUnidad;

            return row;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGridView();
                CargarLabelProductosSeleccionados();
            }
        }

        protected void grdProductos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Producto prod = new Producto();

            prod = CargarDatosProducto(e);

            DataTable dtProductosSeleccionados;
            if (Session["ProductosSeleccionados"] == null)
            {
                dtProductosSeleccionados = CrearTabla();
                Session["ProductosSeleccionados"] = dtProductosSeleccionados;
            }
            else
            {
                dtProductosSeleccionados = (DataTable)Session["ProductosSeleccionados"];
            }

            bool productoAgregado = AgregarFila(dtProductosSeleccionados, prod.IdProducto);

            if (productoAgregado)
            {
                // si el producto no esta en la lista lo agregamos
                
                dtProductosSeleccionados.Rows.Add(CargarDataRow(prod, dtProductosSeleccionados));

                // actualizar la sesion con el datatable actualizado
                Session["ProductosSeleccionados"] = dtProductosSeleccionados;

                // reiniciar y actualizar el label con los productos agregados
                ActualizarLabelProductosSeleccionados();
            }
        }

        protected void grdProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProductos.PageIndex = e.NewPageIndex;
            CargarGridView();
        }
    }
}