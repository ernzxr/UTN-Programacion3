using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class AgregarSucursal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if(!IsPostBack)
            {
                DDLOpcionDefault();
            }
        }

        private void DDLOpcionDefault()
        {
            ddlProvincias.Items.Insert(0, new ListItem("Seleccione una opción", "-1"));
            ddlProvincias.SelectedIndex = 0;
        }
    }
}