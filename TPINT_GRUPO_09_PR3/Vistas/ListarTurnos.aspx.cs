using Entidades;
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
    public partial class ListarTurnos : System.Web.UI.Page
    {
        NegocioTurno negocioTurno = new NegocioTurno();
        //NegocioDetallesTurno negocioDetallesTurno = new NegocioDetallesTurno();
        //NegocioCiclosTurno negocioCiclosTurno = new NegocioCiclosTurno();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                CargarTurnos();
            }
        }

        private void CargarTurnos()
        {
            DataTable dt = negocioTurno.getTurnos();
            gvTurnos.DataSource = dt;
            gvTurnos.DataBind();
        }
    }
}