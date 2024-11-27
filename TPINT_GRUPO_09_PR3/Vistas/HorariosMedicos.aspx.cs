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
            lblMensaje.Text = "";
            string legajo = txtLegajo.Text;

            if (negm.existeLegajo(legajo))
            {
                lblMensaje.Text = "";
                Session["Legajo"] = legajo;
                cargarGrid(legajo);
            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "No existe ese legajo.";
                gvHorariosMedicos.DataSource = null;
                gvHorariosMedicos.DataBind();
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

        protected void gvHorariosMedicos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string s_Legajo = ((Label)gvHorariosMedicos.Rows[e.RowIndex].FindControl("it_lblLegajo")).Text;
            string s_Dia = ((Label)gvHorariosMedicos.Rows[e.RowIndex].FindControl("it_lblDia")).Text;

            int diaEntero = negDS.getIdDiaSemana(s_Dia);

            Session["LegajoEliminar"] = s_Legajo;
            Session["DiaEliminar"] = diaEntero;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "showDeleteModal", "showDeleteModal();", true);
        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            bool elimino = neghm.EliminarHorariosMedicos(Session["LegajoEliminar"].ToString(), Convert.ToInt32(Session["DiaEliminar"]));
            cargarGrid(Session["Legajo"].ToString());
        }

        protected void customHoraFin_ServerValidate(object source, ServerValidateEventArgs args)
        {
            TimeSpan horaFin = TimeSpan.Parse(args.Value);
            if (horaFin.Minutes == 0)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void customHoraInicio_ServerValidate(object source, ServerValidateEventArgs args)
        {
            TimeSpan horaInicio = TimeSpan.Parse(args.Value);
            if (horaInicio.Minutes == 0)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}