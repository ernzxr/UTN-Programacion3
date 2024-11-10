using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoSexo
    {
        AccesoDatos ds = new AccesoDatos();

        public DaoSexo()
        {

        }

        public DataTable getSexo()
        {
            string consulta = "SELECT * FROM Generos";
            return ds.ObtenerTabla("Generos", consulta);
        }
    }
}
