using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;

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
        public DataTable ObtenerCantidadTurnosPorMes(int anio)
        {
            return daoTurno.ObtenerCantidadTurnosPorMes(anio);
        }
    }
}
