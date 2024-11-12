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

        public bool agregarMedico(string legajo, int IDlocalidad, int IDEspecialidad, int IDNacionalidad, int IDGenero, string usuario, string dni, string email, string nombre, string apellido, DateTime fechaN, string direccion, string telefono, Boolean estado)
        {
            int cantFilas = 0;
            Medico medico = new Medico();

            medico.setLegajo(legajo);
            medico.setIdLocalidad(IDlocalidad);
            medico.setIdEspecilidad(IDEspecialidad);
            medico.setIdNacionalidad(IDNacionalidad);
            medico.setIdGenero(IDGenero);
            medico.setUsuario(usuario);
            medico.setDni(dni);
            medico.setEmail(email);
            medico.setNombre(nombre);
            medico.setApellido(apellido);
            medico.setFechaNacimiento(fechaN);
            medico.setDireccion(direccion);
            medico.setTelefono(telefono);
            medico.setEstado(estado);

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

    }
}
