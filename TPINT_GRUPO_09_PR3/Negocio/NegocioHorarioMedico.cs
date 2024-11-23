using Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Reflection;

namespace Negocio
{
    public class NegocioHorarioMedico
    {
        DaoHorarioMedico daoHorario = new DaoHorarioMedico();



        public DataTable ObtenerDiasLaborales(string legajoMedico)
        {
            return daoHorario.ObtenerDiasLaborales(legajoMedico);
        }



        public DataTable ObtenerFechasConTurnosCompletos(string legajoMedico)
        {
            return daoHorario.ObtenerFechasConTurnosCompletos(legajoMedico);
        }

        public bool AgregarHorariosMedicos(HorarioMedico horarioMedico)
        {

            daoHorario.GuardarHorariosMedicos(horarioMedico);
            return true;




        }

        public string[] ObtenerHorasE()
        {
            string[] horas = new string[24];
            for (int i = 0; i < 24; i++)
            {
                {
                    horas[i] = i.ToString("D2") + ":00:00";

                }
            }
                return horas;
        }

        public string[] ObtenerHorasS(string horaEntradaSeleccionada)
        {

            string[] horasDisponibles = new string[24];
            int index = 0;


            for (int i = 0; i < 24; i++)
            {
                string horaGenerada = i.ToString("D2") + ":00:00";


                if (string.Compare(horaGenerada, horaEntradaSeleccionada) > 0)
                {
                    horasDisponibles[index] = horaGenerada;
                    index++;
                }
            }
            string[] horasFinales = new string[index];

            for (int i = 0; i < index; i++)
            {
                horasFinales[i] = horasDisponibles[i];
            }
            return horasFinales;

         }


        public DataTable ObtenerHorariosMedicos(string legajo)
        {
            return daoHorario.ObtenerHorariosMedicos(legajo);
        }

        public bool ActualizarHorariosMedicos(string legajo, int dia, DateTime horaInicio, DateTime horaFin)
        {
            int cantFilas = 0;
            HorarioMedico horarioMedico = new HorarioMedico();

            horarioMedico.setLegajoMedico(legajo);
            horarioMedico.setIdDiaSemana(dia);
            horarioMedico.setHoraInicio(horaInicio);
            horarioMedico.setHoraFin(horaFin);


            cantFilas = daoHorario.ActualizarHorariosMedicos(horarioMedico);
            if (cantFilas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}