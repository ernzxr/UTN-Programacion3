using Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioLocalidad
    {
        public NegocioLocalidad()
        {

        }

        public DataTable getTablaLocalidad(int idProv)
        {
            DaoLocalidad dao = new DaoLocalidad();
            return dao.getLocalidad(idProv);
        }

        public string getDescripcionLocalidad(int idLocalidad)
        {
            DaoLocalidad dao = new DaoLocalidad();
            DataTable dt = dao.getDescripcionLocalidad(idLocalidad);

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
