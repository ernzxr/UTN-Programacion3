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

        public int getIdDiaSemana(string descripcionDia)
        {
            int idDia = 0;

            DataTable dt = dao.GetIdDia(descripcionDia);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                idDia = int.Parse(dr["Id_Dia_Semana_DS"].ToString());
            }

            return idDia;
        }

    }
}
