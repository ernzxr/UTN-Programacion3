﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP2
{
    public partial class EjercicioCinco : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblConfi.Text.ToUpper();
            lblConfi.Font.Size = FontUnit.Point(30);
            lblConfi.Font.Bold = true;

            lblMemoria.Font.Size = FontUnit.Point(15);
            lblMemoria.Font.Bold = true;

            lblAccesorios.Font.Size = FontUnit.Point(15);
            lblAccesorios.Font.Bold = true;

            lblPrecioFinal.Font.Size = FontUnit.Point(15);
            lblPrecioFinal.Font.Bold = true;
        }

        protected void btnCalcularPrecio_Click(object sender, EventArgs e)
        {
            float precio = 0;

            foreach (ListItem item in cblAccesorios.Items)
            {
                if (item.Selected)
                {
                    precio += float.Parse(item.Value);
                }
            }

            precio += float.Parse(ddlMemoria.SelectedValue);

            string precioFinal = precio.ToString("F2");

            lblPrecioFinal.Text = "El precio final es de " + precioFinal + " $";
        }
    }
}