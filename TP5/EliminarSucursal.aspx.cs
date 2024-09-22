using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TP5
{
    public partial class EliminarSucursal : System.Web.UI.Page
    {
        //Negocio obj = new Negocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            rfvIDsucursal.ForeColor = System.Drawing.Color.Red;
        }

        protected void btn_Eliminar_Click(object sender, EventArgs e)
        {

        }
    }
}