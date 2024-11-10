using Dao;
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
    }
}
