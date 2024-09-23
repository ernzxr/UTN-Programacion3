﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace TP5
{
    public partial class Agregar : System.Web.UI.Page
    {
        DML dml = new DML();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                DataTable dt = dml.ObtenerProvincias();
                ddlProvincias.DataSource = dt;
                ddlProvincias.DataTextField = "DescripcionProvincia";
                ddlProvincias.DataValueField = "Id_Provincia";
                ddlProvincias.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int filasAfectadas = dml.AgregarSucursal(txtNombreSucursal.Text, txtDescripcionSucursal.Text, ddlProvincias.SelectedValue, txtDireccionSucursal.Text);
            if (filasAfectadas!=0)
            {

            }
            else
            {

            }
        }
    }
}