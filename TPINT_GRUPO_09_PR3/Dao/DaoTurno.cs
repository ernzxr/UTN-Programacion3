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
         
            string consulta = "SELECT DISTINCT YEAR(Fecha_Tu) AS Anio FROM Turnos ORDER BY Anio;";
            return ds.ObtenerTabla("AniosTurnos", consulta);
        }

        public DataTable ObtenerMesesDeTurnos()
        {
            string consulta = "SELECT DISTINCT MONTH(Fecha_Tu) AS Mes, DATENAME(MONTH, Fecha_Tu) AS NombreMes FROM Turnos ORDER BY Mes;";
            return ds.ObtenerTabla("MesesTurnos", consulta);
        }

        public int ObtenerCantidadTurnosPorMesYAnio(int anio, int mes)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            SqlCommand comando = new SqlCommand();

            comando.Parameters.AddWithValue("@Anio", anio);
            comando.Parameters.AddWithValue("@Mes", mes);

            return accesoDatos.EjecutarProcedimientoAlmacenadoFuncion(comando, "spContarTurnosPorMesYAnio");
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

        public bool CancelarTurnoGestion(string idTurno)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@IDTURNO", SqlDbType.Int);
            SqlParametros.Value = idTurno;
            return ds.EjecutarProcedimientoAlmacenado(comando, "spCancelarTurnoGestion") > 0;
        }

        public Turno getTurno(string idTurno)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@IDTURNO", SqlDbType.Int);
            SqlParametros.Value = idTurno;

            SqlDataReader reader = ds.EjecutarProcedimientoAlmacenadoReader(comando, "spObtenerTurnoPorId");

            try
            {
                if (reader.Read())
                {
                    Turno turno = new Turno();
                    turno.setLegajo_Medico(reader["Legajo_Medico_Tu"].ToString());
                    turno.setFecha(Convert.ToDateTime(reader["Fecha_Tu"]));
                    turno.setHora((TimeSpan)reader["Hora_Tu"]);
                    turno.setDni_Paciente(reader["DNI_Paciente_Tu"].ToString());
                    turno.setIdNacionalidad(Convert.ToInt32(reader["Id_Nacionalidad_Paciente_Tu"]));
                    turno.setAsistencia(Convert.ToBoolean(reader["Asistencia_Tu"]));
                    turno.setObservacion(reader["Observaciones_Tu"].ToString());
                    turno.setIdEspecialidad(Convert.ToInt32(reader["Id_Especialidad"]));
                    return turno;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el turno: " + ex.Message);
            }
            finally
            {
                reader.Close();
            }
        }

        public bool ReprogramarTurnoGestion(string idTurno)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@IDTURNO", SqlDbType.Int);
            SqlParametros.Value = int.Parse(idTurno);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spReprogramarTurnoGestion") > 0;
        }

        public DataTable BuscarTurnosPorFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            SqlCommand comando = new SqlCommand();
           
            comando.Parameters.AddWithValue("@FechaInicio", fechaInicio);
            comando.Parameters.AddWithValue("@FechaFin", fechaFin);
            return ds.EjecutarProcedimientoAlmacenadoLectura(comando, "spBuscarTurnosPorFechas");
        }
    }
   
}
