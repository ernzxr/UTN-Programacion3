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

        public DataTable ObtenerHorariosMedicos(string legajo)
        {
            return daoHorario.ObtenerHorariosMedicos(legajo);
        }

        public bool ActualizarHorariosMedicos(string legajo, int dia, TimeSpan horaInicio, TimeSpan horaFin)
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

        public bool EliminarHorariosMedicos(string legajo, int dia)
        {
            int cantFilas = 0;
            HorarioMedico horarioMedico = new HorarioMedico();

            horarioMedico.setLegajoMedico(legajo);
            horarioMedico.setIdDiaSemana(dia);

            cantFilas = daoHorario.EliminarHorariosMedicos(horarioMedico);
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