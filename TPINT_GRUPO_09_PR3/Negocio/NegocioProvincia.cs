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
    public class NegocioProvincia
    {
        public NegocioProvincia()
        {

        }

        public DataTable getTablaProvincia()
        {
            DaoProvincia dao = new DaoProvincia();
            return dao.getProvincia();
        }

        public string getDescripcionProvincia(int idProvincia)
        {
            string descripcionProvincia = "";
            DataTable dt = new DataTable();

            DaoProvincia dao = new DaoProvincia();

            dt = dao.getDescripcionProvincia(idProvincia);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                descripcionProvincia = dr["Descripcion"].ToString();
            }

            return descripcionProvincia;
        }

    }
}
