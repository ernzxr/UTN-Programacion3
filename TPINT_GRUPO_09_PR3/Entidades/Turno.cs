using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turno
    {
        private string _legajo_Medico;
        private DateTime _fecha;
        private TimeSpan _hora;
        private string _DNI_Paciente;
        private bool _asistencia;
        private string _observacion;

        public Turno()
        {

        }

        public Turno(string legajo_Medico, DateTime fecha, TimeSpan hora, string Dni_Paciente, bool asistencia, string observacion)
        {
            this._legajo_Medico = legajo_Medico;
            this._fecha = fecha;
            this._hora = hora;
            this._DNI_Paciente = Dni_Paciente;
            this._asistencia = asistencia;
            this._observacion = observacion;
        }

        public string getLegajo_Medico() {
            return _legajo_Medico;
        }
        public DateTime getFecha() { 
            return _fecha;
        }
        public TimeSpan getHora() {
            return _hora;
        }
        public string getDNI_Paciente() {
            return _DNI_Paciente;
        }
        public bool getAsistencia() { 
            return _asistencia;
        }
        public string getObservacion()
        {
            return _observacion;
        }
        public void setLegajo_Medico(string legajo_Medico) {
            this._legajo_Medico = legajo_Medico;
        }

        public void setFecha(DateTime fecha)
        {
            this._fecha = fecha;
        }
        public void setHora(TimeSpan hora)
        {
            this._hora = hora;
        }
        public void setAsistencia(bool asistencia)
        {
            this._asistencia = asistencia;
        }
        public void setObservacion(string observacion)
        {
            this._observacion = observacion;
        }

    }
}
