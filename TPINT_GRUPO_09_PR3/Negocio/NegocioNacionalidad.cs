using Dao;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioNacionalidad
    {
        public NegocioNacionalidad()
        {

        }

        public DataTable getTablaNacionalidad()
        {
            DaoNacionalidad dao = new DaoNacionalidad();
            return dao.getNacionalidad();
        }

        public int getIdnacionalidad(string nacionalidad)
        {
            DaoNacionalidad dao = new DaoNacionalidad();
            DataTable dt = dao.getNacionalidadPorNombre(nacionalidad);

            int id = 0;

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                id = int.Parse(dr["Id_Nacionalidad"].ToString());
            }

            return id;
            
        }

        public string getDescripcionNacionalidad(int idNacionalidad)
        {
            DaoNacionalidad dao = new DaoNacionalidad();
            DataTable dt = dao.getDescripcionNacionalidad(idNacionalidad);

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
