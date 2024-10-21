using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

namespace Vistas
{
    public partial class AgregarSucursal : System.Web.UI.Page
    {
        NegocioProvincia negProv = new NegocioProvincia();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                CargarProvincias();
            }
        }
        private void CargarProvincias()
        {
            DataTable dt = negProv.getTabla();
            ddlProvincias.DataSource = dt;
            ddlProvincias.DataTextField = "DescripcionProvincia";
            ddlProvincias.DataValueField = "Id_Provincia";
            ddlProvincias.DataBind();

            ddlProvincias.Items.Insert(0, new ListItem("-- Seleccionar --", "-1"));
            ddlProvincias.Items[0].Attributes["disabled"] = "disabled";
            ddlProvincias.Items[0].Selected = true;
        }
        protected void btnAgregarSucursal_Click(object sender, EventArgs e)
        {
            // creo una instancia de la clase Sucursal (del proyecto Entidades, nota: incluirlo en el proyecto para que funcione)
            Sucursal nuevaSucursal = new Sucursal();

            // capturar los datos del formulario y asignarlos a la instancia de Sucursal
            nuevaSucursal.setNombreSucursal(txtNombreSucursal.Text);
            nuevaSucursal.setDescripcionSucursal(txtDescripcion.Text);
            nuevaSucursal.setIdProvinciaSucursal(int.Parse(ddlProvincias.SelectedValue));
            nuevaSucursal.setDireccionSucursal(txtDireccion.Text);

            // instanciar la clase de negocio
            NegocioSucursal negocioSucursal = new NegocioSucursal();

            // llamar al método AgregarSucursal y verificar el resultado

            bool sucursalAgregada = negocioSucursal.AgregarSucursal(nuevaSucursal);

            if (sucursalAgregada)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = "Sucursal agregada exitosamente.";
            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Error al agregar la sucursal.";
            }

        }
    }
}