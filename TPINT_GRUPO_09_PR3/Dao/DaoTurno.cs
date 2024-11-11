using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    internal class DaoTurno
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

    }
}
