using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoTurno
    {
        AccesoDatos ds = new AccesoDatos();

        public DaoTurno()
        {

        }
        public DataTable getTurnosMedico(string legajo)
        {
            string consulta = "SELECT * FROM Turnos WHERE Legajo_Medico_Tu = " + legajo;
            return ds.ObtenerTabla("Turnos", consulta);
        }

        private void ArmarParametrosAgregarTurno(ref SqlCommand Comando, Turno tur)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@LEGAJOMEDICO", SqlDbType.Char);
            SqlParametros.Value = tur.getLegajo_Medico();
            SqlParametros = Comando.Parameters.Add("@FECHA", SqlDbType.Date);
            SqlParametros.Value = tur.getFecha();
            SqlParametros = Comando.Parameters.Add("@HORA", SqlDbType.Time);
            SqlParametros.Value = tur.getHora();
            SqlParametros = Comando.Parameters.Add("@DNIPACIENTE", SqlDbType.Char);
            SqlParametros.Value = tur.getDNI_Paciente();
            SqlParametros = Comando.Parameters.Add("@IDNACIONALIDADP", SqlDbType.Int);
            SqlParametros.Value = tur.getIdNacionalidad();
            SqlParametros = Comando.Parameters.Add("@ASISTENCIA", SqlDbType.Bit);
            SqlParametros.Value = tur.getAsistencia();

        }

        public bool agregarTurno(Turno tur)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosAgregarTurno(ref comando, tur);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarTurno") > 0;
        }

        public DataTable ObtenerHorariosAsignados(string legajoMedico, DateTime fecha)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@LegajoMedico", legajoMedico);
            comando.Parameters.AddWithValue("@Fecha", fecha);

            return ds.EjecutarProcedimientoAlmacenadoLectura(comando, "spObtenerHorariosAsignados");
        }

        public DataTable getTablaTurnos()
        {
            SqlCommand comando = new SqlCommand();
            return ds.EjecutarProcedimientoAlmacenadoLectura(comando, "spObtenerTurnos");
        }

        public DataTable getTablaTurnosMedico(string legajo)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@LEGAJO", legajo);

            return ds.EjecutarProcedimientoAlmacenadoLectura(comando, "spObtenerTurnosMedico");
        }

        public DataTable getTablaTurnosMedicoFiltrados(string legajo, int filtro)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@LEGAJO", legajo);
            comando.Parameters.AddWithValue("@FILTRO", filtro);

            return ds.EjecutarProcedimientoAlmacenadoLectura(comando, "spObtenerTurnosMedicoFiltrados");
        }

        public DataTable getTablaTurnosMedicoTodos(string legajo)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@LEGAJO", legajo);

            return ds.EjecutarProcedimientoAlmacenadoLectura(comando, "spObtenerTurnosMedicoTodos");
        }

        public DataTable getTablaTurnosPendientes()
        {
            SqlCommand comando = new SqlCommand();
            return ds.EjecutarProcedimientoAlmacenadoLectura(comando, "spObtenerTurnosPendientes");
        }

        public int getTurnosPendientesCount()
        {
            SqlCommand comando = new SqlCommand();
            return ds.EjecutarProcedimientoAlmacenadoFuncion(comando, "spObtenerTurnosPendientesCount");
        }

        public Boolean existeLegajo(string legajo)
        {
            string consulta = "SELECT * FROM Turnos WHERE Legajo_Medico_Tu = '" + legajo + "'";
            return ds.existe(consulta);
        }

        public DataTable BuscarTurnos(string busqueda)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@Busqueda", busqueda);
            return ds.EjecutarProcedimientoAlmacenadoLectura(comando, "spBuscarTurnos");
        }

        public DataTable FiltrarTurnosPorLegajo(string legajoMedico)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@LegajoMedico", legajoMedico);
            return ds.EjecutarProcedimientoAlmacenadoLectura(comando, "spFiltrarTurnosPorLegajo");
        }

        public DataTable FiltrarTurnosPorDni(string dni)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@DniPaciente", dni);
            return ds.EjecutarProcedimientoAlmacenadoLectura(comando, "spFiltrarTurnosPorDni");
        }

        public DataTable FiltrarTurnosPorFecha(DateTime fecha)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@Fecha", fecha);

            return ds.EjecutarProcedimientoAlmacenadoLectura(comando, "spFiltrarTurnosPorDia");
        }
        public DataTable ObtenerAniosDeTurnos()
        {
            // Consulta para obtener los años de los turnos
            string consulta = "SELECT DISTINCT YEAR(Fecha_Tu) AS Anio FROM Turnos ORDER BY Anio;";

            // Utilizar el método para ejecutar consultas directas
            return ds.ObtenerTabla("AniosTurnos", consulta);
        }
        public DataTable ObtenerCantidadTurnosPorMes(int anio)
        {
           
            string consulta = @"
            SELECT MONTH(Fecha) AS Mes, COUNT(*) AS CantidadTurnos
            FROM Turnos
            WHERE YEAR(Fecha) = @Anio
            GROUP BY MONTH(Fecha)
            ORDER BY MONTH(Fecha)"; // Ordenar por mes

           
            SqlCommand comando = new SqlCommand(consulta);
            comando.Parameters.AddWithValue("@Anio", anio);

          
            AccesoDatos accesoDatos = new AccesoDatos();

           
            return accesoDatos.ObtenerTabla(comando);
        }

        public DataTable BuscarTurnosMedico(string legajo, string busqueda)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@LEGAJO", legajo);
            comando.Parameters.AddWithValue("@Busqueda", busqueda);

            return ds.EjecutarProcedimientoAlmacenadoLectura(comando, "spBuscarTurnosMedico");
        }

        public DataTable FiltrarTurnosPorDniFecha(string legajo, string dni, DateTime fecha)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@LegajoMedico", legajo);
            comando.Parameters.AddWithValue("@DniPaciente", dni);
            comando.Parameters.AddWithValue("@Fecha", fecha);

            return ds.EjecutarProcedimientoAlmacenadoLectura(comando, "spFiltrarTurnosMedicoPorDniFecha");
        }

        public int ActualizarTurno(Turno turno)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@LegajoMedico", turno.getLegajo_Medico());
            comando.Parameters.AddWithValue("@DniPaciente", turno.getDNI_Paciente());
            comando.Parameters.AddWithValue("@Fecha", turno.getFecha());
            comando.Parameters.AddWithValue("@Hora", turno.getHora());
            comando.Parameters.AddWithValue("@Asistencia", turno.getAsistencia());
            comando.Parameters.AddWithValue("@Observaciones", turno.getObservacion());

            return ds.EjecutarProcedimientoAlmacenado(comando, "spActualizarTurnoMedico");
        }
    }
   
}
