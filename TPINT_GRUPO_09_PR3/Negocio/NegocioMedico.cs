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
    public class NegocioMedico
    {
        public NegocioMedico()
        {

        }

        public DataTable getTablaMedico()
        {
            DaoMedico dao = new DaoMedico();
            return dao.getMedico();
        }

        public DataTable getTablaMedicoSegunEspecialidad(int id)
        {
            DaoMedico dao = new DaoMedico();
            return dao.getMedicoSegunEspecialidad(id);
        }
    }
}
