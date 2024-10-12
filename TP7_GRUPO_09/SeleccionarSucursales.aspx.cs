﻿using System;
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

        protected void btnSeleccionar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoSeleccionar")
            {
                // Trabajar con el Session
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
      }
    }
