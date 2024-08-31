using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP2
{
    public partial class EjercicioTres : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void lbRojo_Click(object sender, EventArgs e)
        {
            lblMensaje.ForeColor = System.Drawing.Color.Red;
        }
    }
}