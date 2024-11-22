using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Net;

namespace Dao
{
    public class DaoPaciente
    {
        AccesoDatos ds = new AccesoDatos();
        public int agregarPaciente(Paciente paciente)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosAgregarPaciente(ref comando, paciente);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarPaciente");
        }

        public int ActualizarPaciente(Paciente paciente)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosActualizarPaciente(ref comando, paciente);
            return ds.EjecutarProcedimientoAlmacenado(comando, "sp_ActualizarPaciente");
        }

        private void ArmarParametrosAgregarPaciente(ref SqlCommand comando, Paciente paciente)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = comando.Parameters.Add("@DNI", SqlDbType.Char);
            SqlParametros.Value = paciente.getDni();

            SqlParametros = comando.Parameters.Add("@NOMBRE", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getNombre();

            SqlParametros = comando.Parameters.Add("@APELLIDO", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getApellido();

            SqlParametros = comando.Parameters.Add("@SEXO", SqlDbType.Int);
            SqlParametros.Value = paciente.getGenero();

            SqlParametros = comando.Parameters.Add("@FECHANACIMIENTO", SqlDbType.Date);
            SqlParametros.Value = paciente.getFechaNacimiento();

            SqlParametros = comando.Parameters.Add("@NACIONALIDAD", SqlDbType.Int);
            SqlParametros.Value = paciente.getNacionalidad();

            SqlParametros = comando.Parameters.Add("@LOCALIDAD", SqlDbType.Int);
            SqlParametros.Value = paciente.getLocalidad();

            SqlParametros = comando.Parameters.Add("@DIRECCION", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getDireccion();

            SqlParametros = comando.Parameters.Add("@CORREOELECTRONICO", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getEmail();

            SqlParametros = comando.Parameters.Add("@TELEFONO", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getTelefono();

            SqlParametros = comando.Parameters.Add("@ESTADO", SqlDbType.Bit);
            SqlParametros.Value = paciente.getEstado();
        }

        private void ArmarParametrosActualizarPaciente(ref SqlCommand comando, Paciente paciente)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = comando.Parameters.Add("@DNI", SqlDbType.Char);
            SqlParametros.Value = paciente.getDni();

            SqlParametros = comando.Parameters.Add("@NOMBRE", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getNombre();

            SqlParametros = comando.Parameters.Add("@APELLIDO", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getApellido();

            SqlParametros = comando.Parameters.Add("@SEXO", SqlDbType.Int);
            SqlParametros.Value = paciente.getGenero();

            SqlParametros = comando.Parameters.Add("@FECHANACIMIENTO", SqlDbType.Date);
            SqlParametros.Value = paciente.getFechaNacimiento();

            SqlParametros = comando.Parameters.Add("@NACIONALIDAD", SqlDbType.Int);
            SqlParametros.Value = paciente.getNacionalidad();

            SqlParametros = comando.Parameters.Add("@LOCALIDAD", SqlDbType.Int);
            SqlParametros.Value = paciente.getLocalidad();

            SqlParametros = comando.Parameters.Add("@DIRECCION", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getDireccion();

            SqlParametros = comando.Parameters.Add("@CORREOELECTRONICO", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getEmail();

            SqlParametros = comando.Parameters.Add("@TELEFONO", SqlDbType.VarChar);
            SqlParametros.Value = paciente.getTelefono();

            SqlParametros = comando.Parameters.Add("@ESTADO", SqlDbType.Bit);
            SqlParametros.Value = paciente.getEstado();
        }

        public int bajaPaciente(Paciente paciente)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosBajaLogica(ref comando, paciente);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spBajaLogicaPaciente");
        }


        public void ArmarParametrosBajaLogica(ref SqlCommand comando, Paciente paciente)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = comando.Parameters.Add("@DNI", SqlDbType.Char);
            SqlParametros.Value = paciente.getDni();

            SqlParametros = comando.Parameters.Add("@NACIONALIDAD", SqlDbType.Int);
            SqlParametros.Value = paciente.getNacionalidad();
        }

        public Boolean existePaciente(string dni, int idNacionalidad)
        {
            string consulta = "SELECT * FROM Pacientes WHERE Estado_Pa = '" + 1 + "' AND Dni_Pa = '" + dni + "' AND Id_Nacionalidad_Pa = " + idNacionalidad;
            return ds.existe(consulta);
        }

        public Boolean existePacienteDni(string dni)
        {
            string consulta = "SELECT * FROM Pacientes WHERE Estado_Pa = '" + 1 + "' AND Dni_Pa = " + dni;
            return ds.existe(consulta);
        }

        public DataTable filtrarPaciente(string dni, int idNacionalidad)
        {
            string consulta = "SELECT Dni_Pa AS DNI, Nombre_Pa AS Nombre, Apellido_Pa AS Apellido, " +
                "Fecha_Nacimiento_Pa as Fecha_De_Nacimiento, Direccion_Pa AS Direccion, Email_Pa as Email, " +
                "Telefono_Pa as Telefono, Estado_Pa as Estado, Id_Genero_Pa AS Id_Genero, Id_Localidad_Pa AS Id_Localidad, Id_Nacionalidad_Pa AS Id_Nacionalidad" +
                " FROM Pacientes WHERE DNI_Pa = '" + dni + "' AND Id_Nacionalidad_Pa = " + idNacionalidad;
            DataTable tabla = ds.ObtenerTabla("Pacientes", consulta);

            return tabla;
        }

        public DataTable filtrarPacientes()
        {
            string consulta = "SELECT Dni_Pa AS DNI, Nombre_Pa AS Nombre, Apellido_Pa AS Apellido," +
                " Fecha_Nacimiento_Pa as Fecha_De_Nacimiento, Direccion_Pa AS Direccion, " +
                "Email_Pa as Email, Telefono_Pa as Telefono, Estado_Pa as Estado, Id_Genero_Pa AS Id_Genero, Id_Localidad_Pa AS Id_Localidad, Id_Nacionalidad_Pa AS Id_Nacionalidad FROM Pacientes";
            DataTable tabla = ds.ObtenerTabla("Pacientes", consulta);

            return tabla;
        }

        public Boolean existeEmail(string email)
        {
            string consulta = "SELECT * FROM Pacientes WHERE Email_Pa = '" + email + "'";
            return ds.existe(consulta);
        }

        public int ObtenerLocalidadPorDNI(string dniPaciente)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@DniPaciente", dniPaciente);

            DataTable tabla = ds.EjecutarProcedimientoAlmacenadoLectura(comando, "spObtenerLocalidadPorDNI");

            if (tabla.Rows.Count > 0)
            {
                return Convert.ToInt32(tabla.Rows[0]["Id_Localidad_Pa"]);
            }

            return -1;
        }

        public int ObtenerNacionalidadPorDNI(string dniPaciente)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@DniPaciente", dniPaciente);

            DataTable tabla = ds.EjecutarProcedimientoAlmacenadoLectura(comando, "spObtenerNacionalidadPorDNI");

            if (tabla.Rows.Count > 0)
            {
                return Convert.ToInt32(tabla.Rows[0]["Id_Nacionalidad_Pa"]);
            }

            return -1;
        }

        private void ArmarParametrosReportePacientesConMasTurnos(ref SqlCommand Comando, int especialidad, DateTime fechaInicial, DateTime fechaFinal)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IdEspecialidad", SqlDbType.Int);
            SqlParametros.Value = especialidad;

            SqlParametros = Comando.Parameters.Add("@FechaInicio", SqlDbType.Date);
            SqlParametros.Value = fechaInicial;

            SqlParametros = Comando.Parameters.Add("@FechaFinal", SqlDbType.Date);
            SqlParametros.Value = fechaFinal;
        }

        public DataTable reportePacientesConMasTurnos(int especialidad, DateTime fechaInicial, DateTime fechaFinal)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosReportePacientesConMasTurnos(ref comando, especialidad, fechaInicial, fechaFinal);
            DataTable tabla = ds.EjecutarProcedimientoAlmacenadoLectura(comando, "spObtener5PacientesConMasTurnos");
            return tabla;
        }
    }
}
