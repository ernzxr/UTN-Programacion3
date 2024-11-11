using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

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


        public Boolean existePaciente(string dni, int idNacionalidad)
        {
            string consulta = "SELECT * FROM Pacientes WHERE Dni_Pa = '" + dni + "' AND Id_Localidad_Pa = " + idNacionalidad;
            return ds.existe(consulta);
        }

        public Boolean existeEmail(string email)
        {
            string consulta = "SELECT * FROM Pacientes WHERE Email_Pa = '" + email + "'";
            return ds.existe(consulta);
        }
    }
}
