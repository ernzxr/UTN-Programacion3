using Dao;
using Entidades;
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

        public DataTable getTablaLocalidad(Provincia2 provincia)
        {
            DaoLocalidad dao = new DaoLocalidad();
            int idProv = (int)provincia;

            return dao.getLocalidad(idProv);
        }

        public DataTable getLocalidad(int idProv)
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

        public int getIdProvincia(int idLocalidad)
        {
            DaoLocalidad dao = new DaoLocalidad();
            DataTable dt = dao.getIdProvincia(idLocalidad);

            int id = 0;

            if(dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                id = int.Parse(dr["Id_Provincia"].ToString());

            }

            return id;
        }

    }
}
