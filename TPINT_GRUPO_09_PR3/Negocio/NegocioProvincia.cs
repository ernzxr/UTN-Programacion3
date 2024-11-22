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

            Provincia2 provincia = (Provincia2)idProvincia;
            descripcionProvincia = provincia.ToString();

            return descripcionProvincia.ToString();
        }

    }
}
