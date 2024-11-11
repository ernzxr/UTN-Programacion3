using Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioDiaSemana
    {
        public NegocioDiaSemana() { }

        public DataTable getTablaDiaSemana()
        {
            DaoDiaSemana dao = new DaoDiaSemana();
            return dao.getDiaSemana();
        }
    }
}
