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
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //primero verificar si existe el legajo del medico

            //si existe lo vinculo
            DataTable dt = neghm.ObtenerHorariosMedicos(txtLegajo.Text);
            Session["TablaHorariosMedicos"] = dt;
            gvHorariosMedicos.DataSource = dt;
            gvHorariosMedicos.DataBind();
        }

        protected void gvHorariosMedicos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvHorariosMedicos.EditIndex = e.NewEditIndex;

            gvHorariosMedicos.DataSource = Session["TablaHorariosMedicos"];
            gvHorariosMedicos.DataBind();
        }

        protected void gvHorariosMedicos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvHorariosMedicos.EditIndex = -1;

            gvHorariosMedicos.DataSource = Session["TablaHorariosMedicos"];
            gvHorariosMedicos.DataBind();
        }

        protected void gvHorariosMedicos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string s_Legajo = ((Label)gvHorariosMedicos.Rows[e.RowIndex].FindControl("eit_lblLegajo")).Text;
            string s_Dia = ((Label)gvHorariosMedicos.Rows[e.RowIndex].FindControl("eit_lblDia")).Text;
            string s_HoraInicio = ((TextBox)gvHorariosMedicos.Rows[e.RowIndex].FindControl("eit_txtHoraInicio")).Text;
            string s_HoraFin = ((TextBox)gvHorariosMedicos.Rows[e.RowIndex].FindControl("eit_txtHoraFin")).Text;

            int diaEntero = negDS.getIdDiaSemana(s_Dia); //obtener el id del dia segun descripcion

            HorarioMedico horarioMedico = new HorarioMedico();
            horarioMedico.setLegajoMedico(s_Legajo);
            horarioMedico.setIdDiaSemana(diaEntero);
            horarioMedico.setHoraInicio(TimeSpan.Parse(s_HoraInicio));
            horarioMedico.setHoraFin(TimeSpan.Parse(s_HoraFin));

            bool actualizo = neghm.ActualizarHorariosMedicos(horarioMedico.getLegajoMedico(), horarioMedico.getIdDiaSemana(), horarioMedico.getHoraInicio(), horarioMedico.getHoraFin());

            gvHorariosMedicos.EditIndex = -1;
            gvHorariosMedicos.DataSource = Session["TablaHorariosMedicos"];
            gvHorariosMedicos.DataBind();
        }
    }
}