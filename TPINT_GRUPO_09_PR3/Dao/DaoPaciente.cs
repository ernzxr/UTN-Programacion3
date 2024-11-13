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
        public DataTable filtrarPaciente(string dni, int idNacionalidad)
        {
            string consulta = "SELECT Dni_Pa AS DNI, Descripcion_Na AS Nacionalidad, Nombre_Pa AS Nombre, Apellido_Pa AS Apellido, Descripcion_Ge AS Sexo, " +
                "Fecha_Nacimiento_Pa as Fecha_De_Nacimiento, Descripcion_Pr AS Provincia, Descripcion_Lo AS Localidad, Direccion_Pa AS Direccion, Email_Pa as Email, " +
                "Telefono_Pa as Telefono, Estado_Pa as Estado FROM Pacientes INNER JOIN Nacionalidades ON Id_Nacionalidad_Pa = Id_Nacionalidad_Na " +
                "INNER JOIN Generos ON Id_Genero_Pa = Id_Genero_Ge INNER JOIN Localidades ON Id_Localidad_Pa = Id_Localidad_Lo " +
                "INNER JOIN Provincias ON Id_Provincia_Lo = Id_Provincia_Pr WHERE DNI_Pa = '" + dni + "' AND Id_Nacionalidad_Pa = " + idNacionalidad;
            DataTable tabla = ds.ObtenerTabla("Pacientes", consulta);

            return tabla;
        }

        public DataTable filtrarPacientes()
        {
            string consulta = "SELECT Dni_Pa AS DNI, Descripcion_Na AS Nacionalidad, Nombre_Pa AS Nombre, Apellido_Pa AS Apellido, Descripcion_Ge AS Sexo," +
                " Fecha_Nacimiento_Pa as Fecha_De_Nacimiento, Descripcion_Pr AS Provincia, Descripcion_Lo AS Localidad, Direccion_Pa AS Direccion, " +
                "Email_Pa as Email, Telefono_Pa as Telefono, Estado_Pa as Estado FROM Pacientes INNER JOIN Nacionalidades ON Id_Nacionalidad_Pa = Id_Nacionalidad_Na " +
                "INNER JOIN Generos ON Id_Genero_Pa = Id_Genero_Ge INNER JOIN Localidades ON Id_Localidad_Pa = Id_Localidad_Lo INNER JOIN Provincias ON Id_Provincia_Lo = " +
                "Id_Provincia_Pr";
            DataTable tabla = ds.ObtenerTabla("Pacientes", consulta);

            return tabla;
        }

        public Boolean existeEmail(string email)
        {
            string consulta = "SELECT * FROM Pacientes WHERE Email_Pa = '" + email + "'";
            return ds.existe(consulta);
        }
    }
}
