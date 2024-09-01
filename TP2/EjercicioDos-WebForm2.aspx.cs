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

            string zona = "";
            string nombre = string.Empty;
            string apellido= string.Empty;  
            string ciudadSeleccionada= string.Empty;
            string temasElegidos= Session["temasElegidos"] as string;

            if (Request["txtNombre"] != null)
            {
                nombre = Request["txtNombre"].ToString();

            } 
            
            if (Request["txtApellido"] != null)
            {
                apellido = Request["txtApellido"].ToString();

            }
            
            if (Request["ddlCiudad"] != null)
            {
                ciudadSeleccionada = Request["ddlCiudad"].ToString();
                zona = ciudadSeleccionada.Split(' ')[1];
                zona = char.ToString(zona[0]) + zona.Substring(1);
            }

            lblResumen.Text = $"RESUMEN:<br/> Nombre: {nombre}<br/>Apelllido: {apellido} <br/> Zona: {zona} <br/> <br/> Los temas elegidos son: {temasElegidos}";

        }
    }
}