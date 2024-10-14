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
    public partial class SeleccionarSucursales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                CargarListView();
                // CargarDataList();
            }
        }

        protected void CargarListView()
        {
            GestionSucursal gestor = new GestionSucursal();
            lvSucursales.DataSource = gestor.ObtenerSucursales();
            lvSucursales.DataBind();
        }

        /* protected void CargarDataList()
         {

             GestionProvincia gestor = new GestionProvincia();
             dl_Provincias.DataSource = gestor.ObtenerProvincias();
             dl_Provincias.DataBind();

         }
     */
        public DataTable CrearTabla()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id_Sucursal", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Nombre", System.Type.GetType("System.String"));
            dt.Columns.Add("Descripcion", System.Type.GetType("System.String"));

            return dt;
        }

        public void AgregarFila(DataTable tabla, int IdSucursal, string NombreSucursal,
                                string DescripcionSucursal)
        {
            bool existe = false;
            foreach (DataRow r in tabla.Rows)
            {
                if ((Convert.ToInt32(r["Id_Sucursal"])) == IdSucursal)
                {
                    existe = true;
                    break;
                }
            }

            if (!existe)
            {
                DataRow dr = tabla.NewRow();
                dr["Id_Sucursal"] = IdSucursal;
                dr["Nombre"] = NombreSucursal;
                dr["Descripcion"] = DescripcionSucursal;

                tabla.Rows.Add(dr);
                Session["sucursalSeleccionada"] = tabla;
            }
        }

        protected void btnSeleccionar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoSeleccionar")
            {
                string[] sucursalSeleccionada = new string[3];
                sucursalSeleccionada = e.CommandArgument.ToString().Split('-');

                Sucursal sucursal = new Sucursal();
                sucursal.IdSucursal = Convert.ToInt32(sucursalSeleccionada[0]);
                sucursal.NombreSucursal = sucursalSeleccionada[1];
                sucursal.DescripcionSucursal = sucursalSeleccionada[2];

                if (Session["sucursalSeleccionada"] == null)
                {
                    Session["sucursalSeleccionada"] = CrearTabla();
                }
                AgregarFila((DataTable)Session["sucursalSeleccionada"], (int)sucursal.IdSucursal,
                        (string)sucursal.NombreSucursal, (string)sucursal.DescripcionSucursal);
            }
        }

        protected void lvSucursales_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            // Se obtiene el DataPager
            DataPager pager = (DataPager)lvSucursales.FindControl("DataPager1");

            // Establece las nuevas propiedades de la página
            pager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            CargarListView();
        }
        protected void dl_Provincias_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                // obtengo el Id de la provincia desde el CommandArgument
                int provinciaID = Convert.ToInt32(e.CommandArgument);
                FiltrarSucursalesPorProvincia(provinciaID);
            }
        }

        private void FiltrarSucursalesPorProvincia(int provinciaID)
        {
            GestionSucursal gestor = new GestionSucursal();
            DataTable sucursales = gestor.ObtenerSucursalesPorProvincia(provinciaID);
            lvSucursales.DataSource = sucursales;
            lvSucursales.DataBind();
        }

        protected void btn_Buscar_Click(object sender, EventArgs e)
        {
            String nombreSucursal = txtbox_Busqueda.Text.Trim();

            if (!String.IsNullOrEmpty(nombreSucursal)) // Si el TextBox no está vacío
            {
                GestionSucursal gSucursal = new GestionSucursal();
                lvSucursales.DataSource = gSucursal.ObtenerSucursalesPorNombre(nombreSucursal);
                lvSucursales.DataBind();
            }
            else
            {
                CargarListView();
            }
           
        }
    }
    }

