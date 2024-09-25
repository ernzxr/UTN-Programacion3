using System;
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
                CargarSucursales();
            }
        }
        private void validarCarga(int filas)
        {
            if (filas != 0)
            {
                lblResultado.Text = "La sucursal se ha agregado con éxito.";
            }
            else
            {
                lblResultado.Text = "No se ha podido agregar la sucursal.";
            }
        }

        private void LimpiarCampos()
        {
            txtNombreSucursal.Text = "";
            txtDescripcionSucursal.Text = "";
            txtDireccionSucursal.Text = "";
            ddlProvincias.SelectedValue = "0";
        }

        private void CargarSucursales()
        {
            DataTable dt = dml.ObtenerProvincias();
            ddlProvincias.DataSource = dt;
            ddlProvincias.DataTextField = "DescripcionProvincia";
            ddlProvincias.DataValueField = "Id_Provincia";
            ddlProvincias.DataBind();

            ddlProvincias.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
            ddlProvincias.Items[0].Attributes["disabled"] = "disabled";
            ddlProvincias.Items[0].Selected = true;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int filasAfectadas = dml.AgregarSucursal(txtNombreSucursal.Text, txtDescripcionSucursal.Text, ddlProvincias.SelectedValue, txtDireccionSucursal.Text);

            validarCarga(filasAfectadas);

            LimpiarCampos();
        }
    }
}