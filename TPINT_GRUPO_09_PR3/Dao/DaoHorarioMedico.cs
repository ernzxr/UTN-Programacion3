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

        public string ObtenerLegajoPorNombreCompleto(string nombreCompleto)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@NombreCompleto", nombreCompleto);

            DataTable tabla = ds.EjecutarProcedimientoAlmacenadoLectura(comando, "sp_ObtenerLegajoPorNombreCompleto");

            return tabla.Rows.Count > 0 ? tabla.Rows[0]["Legajo_Me"].ToString() : null;
        }

        public DataTable ObtenerDiasLaborales(string legajoMedico)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@LegajoMedico", legajoMedico);

            return ds.EjecutarProcedimientoAlmacenadoLectura(comando, "spObtenerDiasLaborales");
        }

        public DataTable ObtenerFechasAusencias(string legajoMedico)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@LegajoMedico", legajoMedico);

            return ds.EjecutarProcedimientoAlmacenadoLectura(comando, "sp_ObtenerFechasAusencias");

        }

        public DataTable ObtenerFechasConTurnosCompletos(string legajoMedico)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@LegajoMedico", legajoMedico);

            return ds.EjecutarProcedimientoAlmacenadoLectura(comando, "spObtenerFechasConTurnosCompletos");

        }
    }
}
