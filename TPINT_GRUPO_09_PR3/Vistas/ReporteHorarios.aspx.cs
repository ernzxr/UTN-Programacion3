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
    public partial class ReporteHorarios : System.Web.UI.Page
    {
        NegocioNacionalidad NegN = new NegocioNacionalidad();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if(!IsPostBack)
            {
                cargarNacionalidad(ddlEspecialidad);
            }



        }


        protected void cargarNacionalidad(DropDownList ddl)
        {
            DataTable dt = new DataTable();
            dt = NegN.getTablaNacionalidad();

            ddl.DataSource = dt;
            ddl.DataTextField = "Descripcion_Na";
            ddl.DataValueField = "Id_Nacionalidad_Na";
            ddl.DataBind();

            ddl.Items.Insert(0, new ListItem("Seleccionar...", "0"));
        }
    }
}