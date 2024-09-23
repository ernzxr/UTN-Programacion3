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
        DML dml = new DML();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblEliminarSucursal.Font.Bold = true;
            lblEliminarSucursal.Font.Size = FontUnit.Point(20);

            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            rfvIdSucursal.ForeColor = System.Drawing.Color.Red;
        }

        protected void btn_Eliminar_Click(object sender, EventArgs e)
        {
            int resultado = dml.EliminarSucursal(txtIdSucursal.Text);
            if (resultado != 0)
            {
                lblResultado.Text = "Sucursal eliminada correctamente";
            }
            else
            {
                lblResultado.Text = "No se pudo eliminar la sucursal";
            }
        }
    }
}