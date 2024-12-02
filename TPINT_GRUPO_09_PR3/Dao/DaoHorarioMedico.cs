using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Dao
{
    public class DaoHorarioMedico
    {
        AccesoDatos ds = new AccesoDatos();



        public DataTable ObtenerDiasLaborales(string legajoMedico)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@LegajoMedico", legajoMedico);

            return ds.EjecutarProcedimientoAlmacenadoLectura(comando, "spObtenerDiasLaborales");
        }



        public DataTable ObtenerFechasConTurnosCompletos(string legajoMedico)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@LegajoMedico", legajoMedico);

            return ds.EjecutarProcedimientoAlmacenadoLectura(comando, "spObtenerFechasConTurnosCompletos");

        }

       

        private void ArmarParametrosObtenerHorariosMedicos(ref SqlCommand Comando, string legajo)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Legajo", SqlDbType.Char);
            SqlParametros.Value = legajo;
        }

        public DataTable ObtenerHorariosMedicos(string legajo)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosObtenerHorariosMedicos(ref comando, legajo);
            DataTable tabla = ds.EjecutarProcedimientoAlmacenadoLectura(comando, "spObtenerHorariosMedicos");
            return tabla;
        }

        public int ActualizarHorariosMedicos(HorarioMedico horarioMedico)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosActualizarHorariosMedicos(ref comando, horarioMedico);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spActualizarHorariosMedicos");
        }


        private void ArmarParametrosActualizarHorariosMedicos(ref SqlCommand comando, HorarioMedico horarioMedico)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = comando.Parameters.Add("@Legajo", SqlDbType.Char);
            SqlParametros.Value = horarioMedico.getLegajoMedico();

            SqlParametros = comando.Parameters.Add("@Dia", SqlDbType.Int);
            SqlParametros.Value = horarioMedico.getIdDiaSemana();

            SqlParametros = comando.Parameters.Add("@HoraInicio", SqlDbType.Time);
            SqlParametros.Value = horarioMedico.getHoraInicio();

            SqlParametros = comando.Parameters.Add("@HoraFin", SqlDbType.Time);
            SqlParametros.Value = horarioMedico.getHoraFin();
        }

        private void ArmarParametrosEliminarHorariosMedicos(ref SqlCommand comando, HorarioMedico horarioMedico)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = comando.Parameters.Add("@Legajo", SqlDbType.Char);
            SqlParametros.Value = horarioMedico.getLegajoMedico();

            SqlParametros = comando.Parameters.Add("@Dia", SqlDbType.Int);
            SqlParametros.Value = horarioMedico.getIdDiaSemana();
        }

        public int EliminarHorariosMedicos(HorarioMedico horarioMedico)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosEliminarHorariosMedicos(ref comando, horarioMedico);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarHorariosMedicos");
        }

    }
}
