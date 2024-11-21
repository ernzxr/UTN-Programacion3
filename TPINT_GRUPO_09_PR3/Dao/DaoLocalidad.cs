using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoLocalidad
    {
        AccesoDatos ds = new AccesoDatos();

        public DaoLocalidad()
        {

        }

        public DataTable getLocalidad(int idProv)
        {


            string consulta = "SELECT * FROM Localidades INNER JOIN Provincias ON Id_Provincia_Lo = Id_Provincia_Pr WHERE Id_Provincia_Pr = " + idProv;
            return ds.ObtenerTabla("Localidades", consulta);
        }

        
        }

    }

