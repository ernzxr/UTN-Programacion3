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



        public DataTable ObtenerDiasLaborales(string legajoMedico)
        {
            return daoHorario.ObtenerDiasLaborales(legajoMedico);
        }



        public DataTable ObtenerFechasConTurnosCompletos(string legajoMedico)
        {
            return daoHorario.ObtenerFechasConTurnosCompletos(legajoMedico);
        }

        public bool AgregarHorariosMedicos(HorarioMedico horarioMedico)
        {
            
                daoHorario.GuardarHorariosMedicos(horarioMedico);
                return true;

            
            

        }
    }
}