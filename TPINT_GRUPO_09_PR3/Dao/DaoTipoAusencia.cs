using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoTipoAusencia
    {
        AccesoDatos ds = new AccesoDatos();

        public DataTable getTablaTiposAusencias()
        {
            DataTable tabla = ds.ObtenerTabla("Tipos_Ausencias_Medicos", "SELECT * FROM Tipos_Ausencias_Medicos");
            return tabla;
        }
    }
}
