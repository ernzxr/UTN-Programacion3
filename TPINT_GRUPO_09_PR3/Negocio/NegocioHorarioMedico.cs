using Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Negocio
{
    public class NegocioHorarioMedico
    {
        DaoHorarioMedico daoHorario = new DaoHorarioMedico();

        public string ObtenerLegajoPorNombreCompleto(string nombreCompleto)
        {
            return daoHorario.ObtenerLegajoPorNombreCompleto(nombreCompleto);
        }

        public DataTable ObtenerDiasLaborales(string legajoMedico)
        {
            return daoHorario.ObtenerDiasLaborales(legajoMedico);
        }

        public DataTable ObtenerFechasAusencias(string legajoMedico)
        {
            return daoHorario.ObtenerFechasAusencias(legajoMedico);
        }

        public DataTable ObtenerFechasConTurnosCompletos(string legajoMedico)
        {
            return daoHorario.ObtenerFechasConTurnosCompletos(legajoMedico);
        }
    }
}
