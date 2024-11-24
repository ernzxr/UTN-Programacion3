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
    public partial class ModificarHorariosMedicos : System.Web.UI.Page
    {
        NegocioHorarioMedico neghm = new NegocioHorarioMedico();
        NegocioDiaSemana negDS = new NegocioDiaSemana();
        NegocioMedico negm = new NegocioMedico();
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        public void cargarGrid(string legajo)
        {
            DataTable dt = neghm.ObtenerHorariosMedicos(legajo);
            gvHorariosMedicos.DataSource = dt;
            gvHorariosMedicos.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (negm.existeLegajo(txtLegajo.Text))
            {
                lblMensaje.Text = "";
                Session["Legajo"] = txtLegajo.Text;
                cargarGrid(Session["Legajo"].ToString());
            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "No existe ese legajo.";
            }

            txtLegajo.Text = "";
        }


        protected void gvHorariosMedicos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvHorariosMedicos.EditIndex = e.NewEditIndex;

            cargarGrid(Session["Legajo"].ToString());
        }

        protected void gvHorariosMedicos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvHorariosMedicos.EditIndex = -1;

            cargarGrid(Session["Legajo"].ToString());
        }

        protected void gvHorariosMedicos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string s_Legajo = ((Label)gvHorariosMedicos.Rows[e.RowIndex].FindControl("eit_lblLegajo")).Text;
            string s_Dia = ((Label)gvHorariosMedicos.Rows[e.RowIndex].FindControl("eit_lblDia")).Text;
            string s_HoraInicio = ((TextBox)gvHorariosMedicos.Rows[e.RowIndex].FindControl("eit_txtHoraInicio")).Text;
            string s_HoraFin = ((TextBox)gvHorariosMedicos.Rows[e.RowIndex].FindControl("eit_txtHoraFin")).Text;

            int diaEntero = negDS.getIdDiaSemana(s_Dia);

            HorarioMedico horarioMedico = new HorarioMedico();
            horarioMedico.setLegajoMedico(s_Legajo);
            horarioMedico.setIdDiaSemana(diaEntero);
            horarioMedico.setHoraInicio(TimeSpan.Parse(s_HoraInicio));
            horarioMedico.setHoraFin(TimeSpan.Parse(s_HoraFin));

            bool actualizo = neghm.ActualizarHorariosMedicos(horarioMedico.getLegajoMedico(), horarioMedico.getIdDiaSemana(), horarioMedico.getHoraInicio(), horarioMedico.getHoraFin());

            gvHorariosMedicos.EditIndex = -1;
            cargarGrid(Session["Legajo"].ToString());
        }
    }
}