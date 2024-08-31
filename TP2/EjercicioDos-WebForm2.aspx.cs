using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP2
{
    public partial class EjercicioDos_WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //establezco fuente arial
            lblResumen.Font.Name = "Arial";
            //cambio el tamaño a 20
            lblResumen.Font.Size = FontUnit.Point(20);
            //seteo la letra a negrita
            lblResumen.Font.Bold = true;
        }
    }
}