using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoNacionalidad
    {
        AccesoDatos ds = new AccesoDatos();

        public DaoNacionalidad()
        {

        }

        public DataTable getNacionalidad()
        {
            string consulta = "SELECT * FROM Nacionalidades";
            return ds.ObtenerTabla("Nacionalidades", consulta);
        }
    }
}
