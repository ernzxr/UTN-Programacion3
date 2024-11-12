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
    public class NegocioDiaSemana
    {
        DaoDiaSemana dao = new DaoDiaSemana();

        public NegocioDiaSemana() { }

        public DataTable getTablaDiaSemana()
        {
            return dao.getDiaSemana();
        }

        public DiaSemana ObtenerDiaSemanaPorId(int id)
        {
            return dao.ObtenerDiaSemanaPorId(id);
        }
    }
}
