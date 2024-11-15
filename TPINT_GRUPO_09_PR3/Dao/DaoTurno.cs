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

    }
}
