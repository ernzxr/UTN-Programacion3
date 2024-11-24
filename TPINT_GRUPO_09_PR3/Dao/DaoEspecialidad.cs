using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class DaoEspecialidad
    {
        AccesoDatos ds = new AccesoDatos();

        public DaoEspecialidad()
        {

        }

        public DataTable getEspecialidad()
        {
            string consulta = "SELECT * FROM Especialidades";
            return ds.ObtenerTabla("Especialidades", consulta);
        }

        public DataTable getDescripcionEspecialidad(int idEspeciaidad)
        {
            string consulta = "SELECT Descripcion_Es AS Descripcion FROM Especialidades WHERE Id_Especialidad_Es = " + idEspeciaidad;
            return ds.ObtenerTabla("Especialidades", consulta);
        }


    }
}
