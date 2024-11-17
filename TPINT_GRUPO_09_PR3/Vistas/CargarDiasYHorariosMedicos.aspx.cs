using Negocio;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class CargarDiasYHorariosMedicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void txtLegajo_TextChanged(object sender, EventArgs e)
        {

            string legajo = txtLegajo.Text;


            if (txtLegajo.Text.Length == 5)
            {
                NegocioMedico negocioMedico = new NegocioMedico();
                Medico medico = negocioMedico.ObtenerMedicoPorLegajo(legajo);

                if (medico != null)
                {
                    lblMensaje.Text = "Usted va a cargar los horarios de: " + medico.getNombre() + " " + medico.getApellido() + "¿ Desea continuar ?";
                    btnAceptarLegajo.Focus();
                    btnAceptarLegajo.Enabled = true;
                    txtLegajo.Text = " ";
                }

                else
                {
                    lblMensaje.Text = "Legajo no encontrado";
                    btnAceptarLegajo.Enabled = false;

                }
            }

        }
    }
}