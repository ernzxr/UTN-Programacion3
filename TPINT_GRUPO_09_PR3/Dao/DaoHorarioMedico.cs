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
    }
}
