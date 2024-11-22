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
            string consulta = "SELECT * FROM Localidades WHERE Id_Provincia_Lo = " + idProv;
            return ds.ObtenerTabla("Localidades", consulta);
        }

        public DataTable getDescripcionLocalidad(int idLocalidad)
        {
            string consulta = "SELECT Descripcion_Lo AS Descripcion FROM Localidades WHERE Id_Localidad_Lo = " + idLocalidad;
            return ds.ObtenerTabla("Localidades", consulta);
        }

        public DataTable getIdProvincia(int idLocalidad)
        {
            string consulta = "SELECT Id_Provincia_Lo AS Id_Provincia FROM Localidades WHERE Id_Localidad_Lo = " + idLocalidad;
            return ds.ObtenerTabla("Localidades", consulta);
        }
        
        }

    }

