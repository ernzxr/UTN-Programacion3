using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class DiasLibresMedico : System.Web.UI.Page
    {
        NegocioTipoAusencia negTipoAusencia = new NegocioTipoAusencia();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                CargarTiposAusencias();
            }
        }

        private void CargarTiposAusencias()
        {
            DataTable dt = negTipoAusencia.getTablaTipoAusencia();
            ddlTipoAusencia.DataSource = dt;
            ddlTipoAusencia.DataTextField = "Descripcion_TAM";
            ddlTipoAusencia.DataValueField = "Id_Tipo_Ausencia_TAM";
            ddlTipoAusencia.DataBind();

            ddlTipoAusencia.Items.Insert(0, new ListItem("-- Seleccionar --", "-1"));
            ddlTipoAusencia.Items[0].Attributes["disabled"] = "disabled";
            ddlTipoAusencia.Items[0].Selected = true;
        }
    }
}