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
    public class NegocioPaciente
    {
        DaoPaciente dao = new DaoPaciente();
        public bool agregarPaciente(string dni, string nombre, string apellido, int sexo, DateTime fecha, int idnacionalidad, int idlocalidad, string direccion, string email, string telefono, Boolean estado)
        {
            int cantFilas = 0;
            Paciente paciente = new Paciente();

            paciente.setDni(dni);
            paciente.setNombre(nombre);
            paciente.setApellido(apellido);
            paciente.setGenero(sexo);
            paciente.setFechaNacimiento(fecha);
            paciente.setNacionalidad(idnacionalidad);
            paciente.setLocalidad(idlocalidad);
            paciente.setDireccion(direccion);
            paciente.setEmail(email);
            paciente.setTelefono(telefono);
            paciente.setEstado(estado);

            cantFilas = dao.agregarPaciente(paciente);
            if (cantFilas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ModificarPaciente(string dni, string nombre, string apellido, int sexo, DateTime fecha, int idnacionalidad, int idlocalidad, string direccion, string email, string telefono, Boolean estado)
        {
            int cantFilas = 0;
            Paciente paciente = new Paciente();

            paciente.setDni(dni);
            paciente.setNombre(nombre);
            paciente.setApellido(apellido);
            paciente.setGenero(sexo);
            paciente.setFechaNacimiento(fecha);
            paciente.setNacionalidad(idnacionalidad);
            paciente.setLocalidad(idlocalidad);
            paciente.setDireccion(direccion);
            paciente.setEmail(email);
            paciente.setTelefono(telefono);
            paciente.setEstado(estado);

            cantFilas = dao.ActualizarPaciente(paciente);
            if (cantFilas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool bajaPaciente(string dni, int idnacionalidad)
        {
            int cantFilas = 0;
            Paciente paciente = new Paciente();

            paciente.setDni(dni);
            paciente.setNacionalidad(idnacionalidad);

            cantFilas = dao.bajaPaciente(paciente);
            if (cantFilas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable getPaciente(string dni, int idNacionalidad)
        {
            return dao.filtrarPaciente(dni, idNacionalidad);
        }

        public DataTable getPacienteXDNI(string dni)
        {
            return dao.filtrarPacienteXDNI(dni);
        }

        public DataTable getPacienteXNacionalidad(int idNacionalidad)
        {
            return dao.filtrarPacienteXNacionalidad(idNacionalidad);
        }

        public Paciente getPacienteAModificar(string dni, int idNacionalidad)
        {
            DataTable dtPaciente = new DataTable();
            Paciente paciente = new Paciente();

            dtPaciente = dao.filtrarPaciente(dni, idNacionalidad);

            DataRow pac = dtPaciente.Rows[0];

            paciente.setDni(pac["DNI"].ToString());
            paciente.setNacionalidad(int.Parse(pac["Id_Nacionalidad"].ToString()));
            paciente.setNombre(pac["Nombre"].ToString());
            paciente.setApellido(pac["Apellido"].ToString());
            paciente.setGenero(int.Parse(pac["Id_Genero"].ToString()));

            DateTime fechaNacimiento = Convert.ToDateTime(pac["Fecha_De_Nacimiento"]);
            paciente.setFechaNacimiento(fechaNacimiento);

            paciente.setLocalidad(int.Parse(pac["Id_Localidad"].ToString()));
            paciente.setDireccion(pac["Direccion"].ToString());
            paciente.setEmail(pac["Email"].ToString());
            paciente.setTelefono(pac["Telefono"].ToString());

            Boolean estado = Convert.ToBoolean(pac["Estado"]);
            paciente.setEstado(estado);

            return paciente; 
        }

        public DataTable getPacientes()
        {
            return dao.filtrarPacientes();
        }

        public DataTable getPacientesInactivos()
        {
            return dao.filtrarPacientesInactivos();
        }

        public Boolean existePaciente(string dni, int idNacionalidad)
        {
            return dao.existePaciente(dni, idNacionalidad);
        }

        public Boolean existePacienteDni(string dni)
        {
            return dao.existePacienteDni(dni);
        }

        public Boolean existePacienteNacionalidad(int idNacionalidad)
        {
            return dao.existePacienteNacionalidad(idNacionalidad);
        }

        public Boolean existenPacientesInactivos()
        {
            return dao.existenPacientesInactivos();
        }

        public Boolean existeEmail(string email)
        {
            return dao.existeEmail(email);
        }

        public int ObtenerLocalidadPorDNI(string dniPaciente)
        {
            return dao.ObtenerLocalidadPorDNI(dniPaciente);
        }

        public int ObtenerNacionalidadPorDNI(string dniPaciente)
        {
            return dao.ObtenerNacionalidadPorDNI(dniPaciente);
        }

        public DataTable ReportePacientesConMasTurnos(int especialidad, DateTime fechaInicial, DateTime fechaFinal)
        {
            return dao.reportePacientesConMasTurnos(especialidad, fechaInicial, fechaFinal);
        }

        public DataTable ObtenerTurnosPorPaciente(string dni, int idNacionalidadSeleccionada)
        {
            if (string.IsNullOrEmpty(dni))
            {
                throw new ArgumentException("El DNI no puede estar vacío.");
            }

            if (idNacionalidadSeleccionada <= 0)
            {
                throw new ArgumentException("La nacionalidad seleccionada no es válida.");
            }
            
            return dao.ObtenerTurnosPorPaciente(dni, idNacionalidadSeleccionada);
        }


    }
}
