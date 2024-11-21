using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class HorarioMedico
    {
        //Atributos
        private string Legajo_Medico_HM;
        private int Id_Dia_Semana_HM;
        private DateTime Hora_Inicio_HM;
        private DateTime Hora_Fin_HM;

        //Constructor por defecto
        public HorarioMedico()
        {

        }

        //Constructor por parametro
        public HorarioMedico(string legajo, int idDiaSemana, DateTime horaInicio, DateTime horaFin)
        {
            this.Legajo_Medico_HM = legajo;
            this.Id_Dia_Semana_HM = idDiaSemana;
            this.Hora_Inicio_HM = horaInicio;
            this.Hora_Fin_HM = horaFin;
        }

        //Getters y Setters:
        public string getLegajoMedico()
        {
            return Legajo_Medico_HM;
        }

        public void setLegajoMedico(string legajo)
        {
            Legajo_Medico_HM = legajo;
        }

        public int getIdDiaSemana()
        {
            return Id_Dia_Semana_HM;
        }

        public void setIdDiaSemana(int idDiaSemana)
        {
            Id_Dia_Semana_HM = idDiaSemana;
        }

        public DateTime getHoraInicio()
        {
            return Hora_Inicio_HM;
        }

        public void setHoraInicio(DateTime horaInicio)
        {
            Hora_Inicio_HM = horaInicio;
        }

        public DateTime getHoraFin()
        {
            return Hora_Fin_HM;
        }

        public void setHoraFin(DateTime horaFin)
        {
            Hora_Fin_HM = horaFin;
        }

    }
}
