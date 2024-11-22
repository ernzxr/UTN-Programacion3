using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        NegocioTurno negocioTurno = new NegocioTurno(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                lblUsuarioAdmin.Text = Session["Usuario"].ToString();
                lblUsuarioMedico.Text = Session["Usuario"].ToString();
            }

            lblTurnosPendientes.Text = negocioTurno.getTurnosPendientesCount().ToString();
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Home.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}