using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using System.Net;

namespace Negocio
{
    public class NegocioTurno
    {
        DaoTurno daoTurno = new DaoTurno();

        public bool AgregarTurno(Turno tur)
        {
            return daoTurno.agregarTurno(tur);
        }

        public DataTable getTurnos()
        {
            return daoTurno.getTablaTurnos();
        }

        public DataTable getTurnosMedico(string legajo)
        {
            return daoTurno.getTablaTurnosMedico(legajo);
        }

        public DataTable getTurnosMedicoTodos(string legajo)
        {
            return daoTurno.getTablaTurnosMedicoTodos(legajo);
        }

        public DataTable getTurnosMedicoFiltrados(string legajo, int filtro)
        {
            return daoTurno.getTablaTurnosMedicoFiltrados(legajo, filtro);
        }

        public DataTable ObtenerHorariosAsignados(string legajoMedico, DateTime fechaSeleccionada)
        {
            return daoTurno.ObtenerHorariosAsignados(legajoMedico, fechaSeleccionada);
        }

        public DataTable getTurnosPendientes()
        {
            return daoTurno.getTablaTurnosPendientes();
        }

        public int getTurnosPendientesCount()
        {
            return daoTurno.getTurnosPendientesCount();
        }

        public Boolean existeLegajo(string legajo)
        {
            return daoTurno.existeLegajo(legajo);
        }

        public DataTable BuscarTurnos(string busqueda)
        {
            return daoTurno.BuscarTurnos(busqueda);
        }

        public DataTable ObtenerTurnosPorFecha(DateTime fecha)
        {
            return daoTurno.FiltrarTurnosPorFecha(fecha);
        }

        public DataTable ObtenerTurnosPorLegajo(string legajoMedico)
        {
            return daoTurno.FiltrarTurnosPorLegajo(legajoMedico);
        }

        public DataTable ObtenerTurnosPorDni(string dni)
        {
            return daoTurno.FiltrarTurnosPorDni(dni);
        }
        public DataTable ObtenerAniosDeTurnos()
        {
            return daoTurno.ObtenerAniosDeTurnos();
        }

        public DataTable ObtenerMesesDeTurnos()
        {
            return daoTurno.ObtenerMesesDeTurnos();
        }

        public int ReporteCantidadTurnosPorMesYAnio(int anio, int mes)
        {
            DaoTurno daoTurno = new DaoTurno();
            return daoTurno.ObtenerCantidadTurnosPorMesYAnio(anio, mes);
        }

        public DataTable BuscarTurnosPorMedico(string legajo, string busqueda)
        {
            return daoTurno.BuscarTurnosMedico(legajo, busqueda);
        }

        public DataTable ObtenerTurnosPorDniFecha(string legajo, string dni, DateTime fecha)
        {
            return daoTurno.FiltrarTurnosPorDniFecha(legajo, dni, fecha);
        }

        public bool ActualizarTurno(Turno turno)
        {
            try
            {
                int filasAfectadas = daoTurno.ActualizarTurno(turno);
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el turno: " + ex.Message);
            }
        }

        public bool CancelarTurnoGestion(string idTurno)
        {
            return daoTurno.CancelarTurnoGestion(idTurno);
        }

        public Turno getTurno(string idTurno)
        {
            Turno turno = daoTurno.getTurno(idTurno);
            return turno;
        }

        public bool ReprogramarTurnoGestion(string idTurno)
        {
            return daoTurno.ReprogramarTurnoGestion(idTurno);
        }

        public DataTable ObtenerTurnosPorFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            return daoTurno.BuscarTurnosPorFechas(fechaInicio, fechaFin);
        }

        public bool CancelarTurno(int idTurno)
        {
            int cantFilas = 0;
            Turno turno = new Turno();
            turno.setIdTurno(idTurno);

            cantFilas = daoTurno.CancelarTurno(turno);
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
