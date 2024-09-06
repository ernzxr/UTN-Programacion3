using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP3
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblBienvenido.Attributes.Add("style", "font-family: Arial; font-size: 30px; font-weight: bold;");
        }
    }
}