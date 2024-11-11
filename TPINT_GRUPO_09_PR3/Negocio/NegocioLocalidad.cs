using Dao;
using System;
using System.Collections.Generic;
using System.Data;
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
    }
}
