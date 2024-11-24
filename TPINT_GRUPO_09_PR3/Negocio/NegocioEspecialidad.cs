using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dao;
using Entidades;

namespace Negocio
{
    public class NegocioEspecialidad
    {
        public NegocioEspecialidad()
        {

        }

        public DataTable getTablaEspecialidad()
        {
            DaoEspecialidad dao = new DaoEspecialidad();
            return dao.getEspecialidad();
        }

        public string getDescripcionEspecialidad(int idEspecialidad)
        {
            DaoEspecialidad dao = new DaoEspecialidad();
            DataTable dt = dao.getDescripcionEspecialidad(idEspecialidad);

            string descripcion = "";

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                descripcion = dr["Descripcion"].ToString();
            }

            return descripcion;
        }
    }
}
