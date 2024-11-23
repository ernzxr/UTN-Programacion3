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
        DaoMedico dao = new DaoMedico();
        public NegocioMedico()
        {

        }

        public DataTable getTablaMedico()
        {
            return dao.getMedico();
        }

        public DataTable getTablaMedicoSegunEspecialidad(int id)
        {
            return dao.getMedicoSegunEspecialidad(id);
        }

        public bool agregarMedico(Medico medico)
        {
            int cantFilas = 0;
            
            cantFilas = dao.agregarMedico(medico);
            if (cantFilas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Boolean existeMedico(string dni, int idNacionalidad)
        {
            return dao.existeMedico(dni, idNacionalidad);
        }

        public Boolean existeLegajo(string legajo)
        {
            return dao.existeLegajo(legajo);
        }

        public string ObtenerLegajoPorNombreCompleto(string nombreCompleto)
        {
            return dao.ObtenerLegajoPorNombreCompleto(nombreCompleto);
        }

        public Medico ObtenerMedicoPorLegajo(string legajo)
        {
            Medico medico = dao.ObtenerMedicoPorLegajo(legajo);

            return medico;
        }
        public (string legajo, string nombre, string apellido, string dni, DateTime fechaNacimiento,
        string direccion, string telefono, string email, string nombreEspecialidad,
        string nombreLocalidad, string nombreProvincia, string nombreNacionalidad)
    ObtenerDatosMedicoPorUsuario(string usuario) // Aquí también debe coincidir
        {
            return dao.ObtenerDatosMedicoPorUsuario(usuario); // Llamada al método
        }
    }
}
