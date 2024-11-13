using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;

namespace Negocio
{
    public class NegocioTurno
    {
        DaoTurno daoTurno = new DaoTurno();

        public bool AgregarTurno(Turno tur)
        {
            return daoTurno.agregarTurno(tur);
        }

        public DataTable ObtenerHorariosAsignados(string legajoMedico, DateTime fechaSeleccionada)
        {
            return daoTurno.ObtenerHorariosAsignados(legajoMedico, fechaSeleccionada);
        }
    }
}
