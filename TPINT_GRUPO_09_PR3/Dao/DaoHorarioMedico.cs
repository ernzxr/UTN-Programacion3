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

        public void GuardarHorariosMedicos(HorarioMedico horarioMedico)
        {

            SqlCommand cmd = new SqlCommand();

            TimeSpan horaTransformada = horarioMedico.getHoraInicio().TimeOfDay;
            TimeSpan horaTransformadaFin = horarioMedico.getHoraFin().TimeOfDay;

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Legajo", horarioMedico.getLegajoMedico());
            cmd.Parameters.AddWithValue("@Dia", horarioMedico.getIdDiaSemana());
            cmd.Parameters.AddWithValue("@HoraInicio", horaTransformada);
            cmd.Parameters.AddWithValue("@HoraFin", horaTransformadaFin);
            try
            {
                ds.EjecutarProcedimientoAlmacenado(cmd, "sp_AgregarHorarioMedico");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar el procedimiento almacenado: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
                throw new Exception("Error al guardar horario médico: " + ex.Message, ex); // Re-lanzar la excepción con más contexto
            }
        }
    }
}
