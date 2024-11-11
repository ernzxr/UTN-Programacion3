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
    }
}
