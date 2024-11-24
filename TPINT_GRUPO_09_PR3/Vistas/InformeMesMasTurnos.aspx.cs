using Negocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class InformeMesMasTurnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack) // Verifica que no sea un postback
            {
                CargarAnios();
            }
        }
        private void CargarAnios()
        {
            NegocioTurno negocioTurnos = new NegocioTurno();
            DataTable dtAnios = negocioTurnos.ObtenerAniosDeTurnos();
            ddlAnios.DataSource = dtAnios;
            ddlAnios.DataTextField = "Anio"; // Columna a mostrar
            ddlAnios.DataValueField = "Anio"; // Valor que tomará cada item
            ddlAnios.DataBind();
            ddlAnios.Items.Insert(0, new ListItem("--Seleccione una opción--", "0"));
        }
        
    }

}




