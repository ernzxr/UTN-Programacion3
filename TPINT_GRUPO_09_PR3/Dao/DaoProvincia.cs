using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoProvincia
    {
        AccesoDatos ds = new AccesoDatos();

        public DaoProvincia()
        {

        }

        public DataTable getProvincia()
        {
            string consulta = "SELECT * FROM Provincias";
            return ds.ObtenerTabla("Provincias", consulta);
        }

        public DataTable getDescripcionProvincia(int idProvincia)
        {
            string consulta = "SELECT Descripcion_Pr AS Descripcion FROM PROVINCIAS WHERE Id_Provincia_Pr = " + idProvincia;
            return ds.ObtenerTabla("Provincias", consulta);
        }

    }
}
