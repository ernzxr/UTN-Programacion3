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
    public class DaoProvincia
    {
        AccesoDatos ds = new AccesoDatos();

        public DataTable getTablaProvincia()
        {
            DataTable tabla = ds.ObtenerTabla("Provincia", "Select * from Provincia");
            return tabla;
        }
    }
}
