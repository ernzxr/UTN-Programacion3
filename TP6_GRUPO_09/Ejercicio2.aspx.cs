﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP6_GRUPO_09
{
    public partial class Ejercicio2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbEliminarProductos_Click(object sender, EventArgs e)
        {
               Session["ProductosSeleccionados"] = null;

               lblMensaje.Text = "Se han eliminado los productos seleccionados";
            
        }
    }
}