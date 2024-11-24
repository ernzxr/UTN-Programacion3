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

        public Boolean existeMedico(string legajo)
        {
            return dao.existeMedico(legajo);
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

        public Boolean existeLegajo(string legajo)
        {
            return dao.existeLegajo(legajo);
        }


        public DataTable getMedico(string legajo)
        {
            return dao.filtrarMedico(legajo);
        }

        public DataTable getMedico()
        {
            return dao.filtrarMedico();
        }

        public bool bajaMedico(string legajo)
        {
            int cantFilas = 0;
            Medico medico = new Medico();

            medico.setDni(legajo);
            

            cantFilas = dao.bajaMedico(medico);
            if (cantFilas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ModificarMedico(int especialidad, string dni, string nombre, string apellido, int sexo, DateTime fecha, int idnacionalidad, int idlocalidad, string direccion, string email, string telefono, Boolean estado)
        {
            int cantFilas = 0;
            Medico medico = new Medico();

            medico.setIdEspecilidad(especialidad);
            medico.setDni(dni);
            medico.setNombre(nombre);
            medico.setApellido(apellido);
            medico.setIdGenero(sexo);
            medico.setFechaNacimiento(fecha);
            medico.setIdNacionalidad(idnacionalidad);
            medico.setIdLocalidad(idlocalidad);
            medico.setDireccion(direccion);
            medico.setEmail(email);
            medico.setTelefono(telefono);
            medico.setEstado(estado);

            cantFilas = dao.ActualizarMedico(medico);
            if (cantFilas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
               
        public DataTable getMedicoPorLegajo(string legajo)
        {
             return dao.getMedicoPorLegajo(legajo);
        }
    }


}
