using Negocio;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Vistas
{
    public partial class CargarDiasYHorariosMedicos : System.Web.UI.Page
    {
        NegocioHorarioMedico horarioE = new NegocioHorarioMedico();
        NegocioHorarioMedico horarioS = new NegocioHorarioMedico();

        private string horaEntradaSeleccionada;

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
            CargarHorasEntradaM();
            CargarHorasSalidaM();
            }
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
                    lblMensaje.Text = "Importante: Usted va a cargar los horarios de: " + medico.getNombre() + " " + medico.getApellido() ;
                    
                    if (cklDias.Items.Count > 0)
                    {
                        cklDias.Items[0].Selected = false;  
                        cklDias.Focus();  // Establece el foco en el CheckBoxList
                    }

                }

                else
                {
                    lblMensaje.Text = "Legajo no encontrado";
                }
            }
                   
        }

        protected void btnCancelarLegajo_Click(object sender, EventArgs e)
        {
            txtLegajo.Text = "";
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            string legajo = txtLegajo.Text;

            string diasSeleccionados = "";

            foreach (ListItem item in cklDias.Items)
            {
                if (item.Selected)
                {

                    if (diasSeleccionados != "") // si hay dias seleccionados, agrega coma y el nvo dia
                    {
                        diasSeleccionados += "," + item.Value;
                    }
                    else
                    {
                        diasSeleccionados += item.Value; // si no hay dias cargados agrega el nvo dia sin coma
                    }

                }
            }

            if (string.IsNullOrEmpty(diasSeleccionados))
            {
                lblMensaje.Text = "Debe seleccionar al menos un día.";
                return;
            }

            string entradaHoraInicio = ddlHEntrada.Text;
            string entradaHoraFin = ddlHSalida.Text;

            DateTime horaInicio;
            DateTime horaFin;



            if (!DateTime.TryParse(entradaHoraInicio, out horaInicio))
            {
                lblMensaje.Text = "Formato de hora de entrada incorrecto. Asegúrate de que la hora esté en el formato correcto (HH:mm:ss).";
                return;
            }

            if (!DateTime.TryParse(entradaHoraFin, out horaFin))
            {
                lblMensaje.Text = "Formato de hora de salida incorrecto. Asegúrate de que la hora esté en el formato correcto (HH:mm:ss).";
                return;
            }

            bool resultado = true;


            string[] diasArray = diasSeleccionados.Split(',');

            try
            {

                foreach (string dia in diasArray)
                {
                    string diaLimpiado = dia.Trim();

                    if (int.TryParse(diaLimpiado, out int diaInt))
                    {

                        HorarioMedico horarioMedico = new HorarioMedico();
                        horarioMedico.setLegajoMedico(legajo);
                        horarioMedico.setIdDiaSemana(diaInt);
                        horarioMedico.setHoraInicio(horaInicio);
                        horarioMedico.setHoraFin(horaFin);

                        NegocioHorarioMedico negocio = new NegocioHorarioMedico();
                        bool result1 = negocio.AgregarHorariosMedicos(horarioMedico);


                        if (!result1)
                        {
                            resultado = false;
                            break;
                        }
                    }
                    else
                    {
                        lblMensaje.Text = "El valor del día seleccionado no es válido: " + dia;
                        resultado = false;
                        break;
                    }

                }

                if (resultado)
                {
                    lblMensaje.Text = "Los horarios se han guardado correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Ocurrió un error al guardar los horarios.";
                }

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Se produjo un error inesperado: " + ex.Message;
            }
            cklDias.ClearSelection();
            txtLegajo.Text = "";
            ddlHEntrada.Items.Clear();
            ddlHSalida.Items.Clear();
        }




    

        public void CargarHorasEntradaM()
        {
            string[] horasE = horarioE.ObtenerHorasE();
            ddlHEntrada.DataSource = horasE;
            ddlHEntrada.DataBind();
            
        }




      protected void ddlHEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            horaEntradaSeleccionada = ddlHEntrada.SelectedValue;
            CargarHorasSalidaM();


        }

        protected void ddlHSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            string horaSalida = ddlHSalida.SelectedValue;

        }



        public void CargarHorasSalidaM()
        {
            if (!string.IsNullOrEmpty(horaEntradaSeleccionada))
            {

                string[] horasS = horarioS.ObtenerHorasS(horaEntradaSeleccionada);
                ddlHSalida.DataSource = horasS;
                ddlHSalida.DataBind();
            }
            else
            {
                lblMsjeErrorCargaHorario.Text = "Por favor, selecciona primero una hora de entrada.";
            }
        }
        
        




    }
}