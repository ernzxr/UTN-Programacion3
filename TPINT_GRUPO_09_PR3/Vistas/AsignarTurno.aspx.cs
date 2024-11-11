using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;

namespace Vistas
{
    public partial class AsignarTurno : System.Web.UI.Page
    {
        NegocioEspecialidad negEspecialidad = new NegocioEspecialidad();
        NegocioMedico negMedico = new NegocioMedico();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                CargarEspecialidades();
            }
        }

        private void CargarEspecialidades()
        {
            DataTable dt = negEspecialidad.getTablaEspecialidad();
            ddlEspecialidades.DataSource = dt;
            ddlEspecialidades.DataTextField = "Descripcion_Es";
            ddlEspecialidades.DataValueField = "Id_Especialidad_Es";
            ddlEspecialidades.DataBind();

            ddlEspecialidades.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
            ddlEspecialidades.Items[0].Attributes["disabled"] = "disabled";
            ddlEspecialidades.Items[0].Selected = true;

            ddlProfesionales.Items.Clear();
            ddlProfesionales.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
            ddlProfesionales.Items[0].Attributes["disabled"] = "disabled";
            ddlProfesionales.Items[0].Selected = true;
        }

        protected void EspecialidadSeleccionada(object sender, EventArgs e)
        {
            int especialidadId = Convert.ToInt32(ddlEspecialidades.SelectedValue);
            DataTable dt = negMedico.getTablaMedicoSegunEspecialidad(especialidadId);

            ddlProfesionales.Items.Clear();

            dt.Columns.Add("NombreCompleto", typeof(string), "Nombre_Me + ' ' + Apellido_Me");
            int autoIncrementValue = 1;

            foreach (DataRow row in dt.Rows)
            {
                string nombreCompleto = row["NombreCompleto"].ToString();

                // Agregar el ítem al DropDownList con value autoincremental
                ddlProfesionales.Items.Add(new ListItem(nombreCompleto, autoIncrementValue.ToString()));
                autoIncrementValue++; // Incrementar el valor para el siguiente ítem
            }

            ddlProfesionales.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
            ddlProfesionales.Items[0].Attributes["disabled"] = "disabled";
            ddlProfesionales.Items[0].Selected = true;
        }
    }
}