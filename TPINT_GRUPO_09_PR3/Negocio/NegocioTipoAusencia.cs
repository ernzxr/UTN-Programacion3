using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades;

namespace Negocio
{
    public class NegocioTipoAusencia
    {
        public DataTable getTablaTipoAusencia()
        {
            DaoTipoAusencia dao = new DaoTipoAusencia();
            return dao.getTablaTipoAusencia();
        }
    }
}
