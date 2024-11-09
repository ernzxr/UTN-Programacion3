using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AusenciasMedico
    {
        //Atributos
        private int LegajoMedico;
        private int TipoAusencia;
        private DateTime FechaInicio;
        private DateTime FechaFin;

        //Constructor por defecto
        public AusenciasMedico()
        {

        }

        //Constructor por parametro
        public AusenciasMedico(int legajo, int tipoAusencia, DateTime fechaInicio,
                        DateTime fechaFin)
        {
            this.LegajoMedico = legajo;
            this.TipoAusencia = tipoAusencia;
            this.FechaInicio = fechaInicio;
            this.FechaFin = fechaFin;
        }

        //Getters y Setters:
        public int getLegajoMedico()
        {
            return LegajoMedico;
        }

        public void setLegajoMedico(int legajo)
        {
            LegajoMedico = legajo;
        }

        public int getTipoAusencia()
        {
            return TipoAusencia;
        }

        public void setTipoAusencia(int tipoAusencia)
        {
            TipoAusencia = tipoAusencia;
        }

        public DateTime getFechaInicio()
        {
            return FechaInicio;
        }

        public void setFechaInicio(DateTime fechaInicio)
        {
            FechaInicio = fechaInicio;
        }

        public DateTime getFechaFin()
        {
            return FechaFin;
        }

        public void setFechaFin(DateTime fechaFin)
        {
            FechaFin = fechaFin;
        }
    }
}
