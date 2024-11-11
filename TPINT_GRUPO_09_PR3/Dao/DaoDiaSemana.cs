using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
   public class DaoDiaSemana
    {
        AccesoDatos ds = new AccesoDatos();
        public DaoDiaSemana() { }

        public DataTable getDiaSemana()
        {
            string consulta = "SELECT * FROM Dias_Semanas";
            return ds.ObtenerTabla("Dias_Semanas", consulta);
        }

    }
}
