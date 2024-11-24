using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.ComponentModel.Design;

namespace Dao
{
    public class DaoMedico
    {
        AccesoDatos ds = new AccesoDatos();
       
        private string connectionString; 
        
      
        public DaoMedico()
        {
          connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=UTN2C2024PR3CLINICA;Integrated Security=True;";
        }
        
           
        public int agregarMedico(Medico medico)
        {
            SqlCommand cmd = new SqlCommand();
            ArmarParametrosAgregarMedico(ref cmd, medico);
            return ds.EjecutarProcedimientoAlmacenado(cmd, "spAgregarMedico");
        }

        private void ArmarParametrosAgregarMedico(ref SqlCommand cmd, Medico medico)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = cmd.Parameters.Add("@LEGAJO", SqlDbType.Char);
            SqlParametros.Value = medico.getLegajo();

            SqlParametros = cmd.Parameters.Add("@LOCALIDAD", SqlDbType.Int);
            SqlParametros.Value = medico.getIdLocalidad();

            SqlParametros = cmd.Parameters.Add("@ESPECIALIDAD", SqlDbType.Int);
            SqlParametros.Value = medico.getIdEspecialidad();

            SqlParametros = cmd.Parameters.Add("@NACIONALIDAD", SqlDbType.Int);
            SqlParametros.Value = medico.getNacionalidad();

            SqlParametros = cmd.Parameters.Add("@GENERO", SqlDbType.Int);
            SqlParametros.Value = medico.getGenero();

            SqlParametros = cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar);
            SqlParametros.Value = medico.getUsuario();

            SqlParametros = cmd.Parameters.Add("@DNI", SqlDbType.Char);
            SqlParametros.Value = medico.getDni();

            SqlParametros = cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar);
            SqlParametros.Value = medico.getEmail();

            SqlParametros = cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar);
            SqlParametros.Value = medico.getNombre();

            SqlParametros = cmd.Parameters.Add("@APELLIDO", SqlDbType.VarChar);
            SqlParametros.Value = medico.getApellido();

            SqlParametros = cmd.Parameters.Add("@FECHANACIMIENTO", SqlDbType.DateTime);
            SqlParametros.Value = medico.getFechaNacimiento();

            SqlParametros = cmd.Parameters.Add("@DIRECCION", SqlDbType.VarChar);
            SqlParametros.Value = medico.getDireccion();

            SqlParametros = cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar);
            SqlParametros.Value = medico.getTelefono();
        }


        public DataTable getMedico()
        {
            string consulta = "SELECT * FROM Medicos";
            return ds.ObtenerTabla("Medicos", consulta);
        }

        public DataTable getMedicoSegunEspecialidad(int id)
        {
            string consulta = "SELECT * FROM Medicos WHERE Id_Especialidad_Me =" + id;
            return ds.ObtenerTabla("Medicos", consulta);
        }
        public Boolean existeMedico(string dni, int idNacionalidad)
        {
            string consulta = "SELECT * FROM Medicos WHERE DNI_Me = '" + dni + "' AND Id_Nacionalidad_Me = " + idNacionalidad;
            return ds.existe(consulta);
        }

        public Boolean existeMedico(string legajo)
        {
            string consulta = "SELECT * FROM Medicos WHERE Legajo_Me = '" + legajo + "'";
            return ds.existe(consulta);
        }

        public string ObtenerLegajoPorNombreCompleto(string nombreCompleto)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@NombreCompleto", nombreCompleto);

            DataTable tabla = ds.EjecutarProcedimientoAlmacenadoLectura(comando, "sp_ObtenerLegajoPorNombreCompleto");

            return tabla.Rows.Count > 0 ? tabla.Rows[0]["Legajo_Me"].ToString() : null;
        }

        public Medico ObtenerMedicoPorLegajo(string legajo)
        {
           SqlConnection conexion = new SqlConnection(connectionString); 
            //SqlConnection conexion = ds.ObtenerConexion(); 
            
                SqlCommand comando = new SqlCommand("SELECT Legajo_Me, Nombre_Me, Apellido_Me FROM Medicos WHERE Legajo_Me = @legajo", conexion);
                comando.Parameters.AddWithValue("@legajo", legajo);

                try
                {
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        Medico medico = new Medico();

                        medico.setLegajo(reader["Legajo_Me"].ToString());
                        medico.setNombre(reader["Nombre_Me"].ToString());
                        medico.setApellido(reader["Apellido_Me"].ToString());
                        return medico;
                        
                    }
                    else
                    {
                        return null;
                        

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al acceder a la base de datos: " + ex.Message);
                }
            
        }

        public Medico ObtenerDatosMedicoPorUsuario(string usuario)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand(
                    "SELECT Legajo_Me, Nombre_Me, Apellido_Me, DNI_Me, Fecha_Nacimiento_Me, Direccion_Me, " +
                    "Telefono_Me, Email_Me, Id_Localidad_Me, Id_Especialidad_Me, Id_Nacionalidad_Me " +
                    "FROM Medicos WHERE Usuario_Me = @Usuario AND Estado_Me = 1", conexion);

                comando.Parameters.AddWithValue("@Usuario", usuario);

                try
                {
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        Medico medico = new Medico();
                        medico.setLegajo(reader["Legajo_Me"].ToString());
                        medico.setNombre(reader["Nombre_Me"].ToString());
                        medico.setApellido(reader["Apellido_Me"].ToString());
                        medico.setDni(reader["DNI_Me"].ToString());
                        medico.setFechaNacimiento(Convert.ToDateTime(reader["Fecha_Nacimiento_Me"]));
                        medico.setDireccion(reader["Direccion_Me"].ToString());
                        medico.setTelefono(reader["Telefono_Me"].ToString());
                        medico.setEmail(reader["Email_Me"].ToString());
                        medico.setIdLocalidad(Convert.ToInt32(reader["Id_Localidad_Me"]));
                        medico.setIdEspecilidad(Convert.ToInt32(reader["Id_Especialidad_Me"]));
                        medico.setIdNacionalidad(Convert.ToInt32(reader["Id_Nacionalidad_Me"]));
                        return medico;
                    }
                    else
                    {
                        return null; // No se encontró el médico
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los datos del médico: " + ex.Message);
                }
            }
        }

        public Boolean existeLegajo(string legajo)
        {
            string consulta = "SELECT * FROM Medicos WHERE Legajo_Me = '" + legajo + "´";
            return ds.existe(consulta);
        }


        public DataTable filtrarMedico(string legajo)
        {
            string consulta = "SELECT Legajo_Me AS Legajo,Descripcion_Es AS Especialidad,Nombre_Me As Nombre,Apellido_ME AS Apellido,DNI_Me AS DNI," +
                "Descripcion_Ge AS Genero,Fecha_Nacimiento_Me AS Fecha_De_Nacimiento,Descripcion_Na AS Nacionalidad,Descripcion_Pr AS Provincia," +
                "Descripcion_Lo AS Localidad,Direccion_Me AS Direccion,Email_ME AS Email,Telefono_Me AS Telefono,Estado_Me AS Estado FROM Medicos INNER JOIN Especialidades ON Id_Especialidad_Me = Id_Especialidad_Es " +
                "INNER JOIN Generos ON Id_Genero_Me = Id_Genero_Ge INNER JOIN Nacionalidades ON Id_Nacionalidad_Me =Id_Nacionalidad_Na " +
                "INNER JOIN Localidades ON Id_Localidad_Me = Id_Localidad_Lo INNER JOIN Provincias ON Id_Provincia_Lo = Id_Provincia_Pr " +
                "WHERE Legajo_Me='" + legajo + "'";
            DataTable tabla = ds.ObtenerTabla("Medicos", consulta);

            return tabla;
        }
        public DataTable filtrarMedico()
        {
            string consulta = "SELECT Legajo_Me AS Legajo,Descripcion_Es AS Especialidad,Nombre_Me As Nombre,Apellido_ME AS Apellido,DNI_Me AS DNI," +
                "Descripcion_Ge AS Genero,Fecha_Nacimiento_Me AS Fecha_De_Nacimiento,Descripcion_Na AS Nacionalidad,Descripcion_Pr AS Provincia," +
                "Descripcion_Lo AS Localidad,Direccion_Me AS Direccion,Email_ME AS Email,Telefono_Me AS Telefono,Estado_Me AS Estado FROM Medicos INNER JOIN Especialidades ON Id_Especialidad_Me = Id_Especialidad_Es " +
                "INNER JOIN Generos ON Id_Genero_Me = Id_Genero_Ge INNER JOIN Nacionalidades ON Id_Nacionalidad_Me =Id_Nacionalidad_Na " +
                "INNER JOIN Localidades ON Id_Localidad_Me = Id_Localidad_Lo INNER JOIN Provincias ON Id_Provincia_Lo = Id_Provincia_Pr ";
            DataTable tabla = ds.ObtenerTabla("Medicos", consulta);

            return tabla;
        }
        public int bajaMedico(Medico medico)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosBajaLogica(ref comando, medico);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spBajaLogicaMedico");
        }

        public int ActualizarMedico(Medico medico)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosActualizarMedico(ref comando, medico);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spActualizarMedico");

        }

        private void ArmarParametrosActualizarMedico(ref SqlCommand comando, Medico medico)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = comando.Parameters.Add("@LEGAJO", SqlDbType.Char);
            SqlParametros.Value = medico.getLegajo();

            SqlParametros = comando.Parameters.Add("@Especialidad", SqlDbType.Char);
            SqlParametros.Value = medico.getIdEspecialidad();

            SqlParametros = comando.Parameters.Add("@DNI", SqlDbType.Char);
            SqlParametros.Value = medico.getDni();

            SqlParametros = comando.Parameters.Add("@NOMBRE", SqlDbType.VarChar);
            SqlParametros.Value = medico.getNombre();

            SqlParametros = comando.Parameters.Add("@APELLIDO", SqlDbType.VarChar);
            SqlParametros.Value = medico.getApellido();

            SqlParametros = comando.Parameters.Add("@SEXO", SqlDbType.Int);
            SqlParametros.Value = medico.getGenero();

            SqlParametros = comando.Parameters.Add("@FECHANACIMIENTO", SqlDbType.Date);
            SqlParametros.Value = medico.getFechaNacimiento();

            SqlParametros = comando.Parameters.Add("@NACIONALIDAD", SqlDbType.Int);
            SqlParametros.Value = medico.getNacionalidad();

            SqlParametros = comando.Parameters.Add("@LOCALIDAD", SqlDbType.Int);
            SqlParametros.Value = medico.getIdLocalidad();

            SqlParametros = comando.Parameters.Add("@DIRECCION", SqlDbType.VarChar);
            SqlParametros.Value = medico.getDireccion();

            SqlParametros = comando.Parameters.Add("@CORREOELECTRONICO", SqlDbType.VarChar);
            SqlParametros.Value = medico.getEmail();

            SqlParametros = comando.Parameters.Add("@TELEFONO", SqlDbType.VarChar);
            SqlParametros.Value = medico.getTelefono();

            SqlParametros = comando.Parameters.Add("@ESTADO", SqlDbType.Bit);
            SqlParametros.Value = medico.getEstado();
        }

        public void ArmarParametrosBajaLogica(ref SqlCommand comando, Medico medico)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = comando.Parameters.Add("@LEGAJO", SqlDbType.Char);
            SqlParametros.Value = medico.getLegajo();

        }


        public DataTable getMedicoPorLegajo(string legajo)
        {
            string consulta = "SELECT Legajo_Me AS Legajo, Descripcion_Es AS Especialidad, Nombre_Me AS Nombre, Apellido_ME AS Apellido, DNI_Me AS DNI, " +
                             "Descripcion_Ge AS Sexo, Fecha_Nacimiento_Me AS Fecha_De_Nacimiento, Descripcion_Na AS Nacionalidad, Descripcion_Pr AS Provincia, " +
                             "Descripcion_Lo AS Localidad, Direccion_Me AS Direccion, Email_ME AS Email, Telefono_Me AS Telefono, Estado_Me AS Estado, " +
                             "Id_Nacionalidad_Me AS Id_Nacionalidad, Id_Genero_Me AS Id_Genero, Id_Provincia_Pr AS Id_Provincia, Id_Localidad_Me AS Id_Localidad " +
                             "FROM Medicos " +
                             "INNER JOIN Especialidades ON Id_Especialidad_Me = Id_Especialidad_Es " +
                             "INNER JOIN Generos ON Id_Genero_Me = Id_Genero_Ge " +
                             "INNER JOIN Nacionalidades ON Id_Nacionalidad_Me = Id_Nacionalidad_Na " +
                             "INNER JOIN Localidades ON Id_Localidad_Me = Id_Localidad_Lo " +
                             "INNER JOIN Provincias ON Id_Provincia_Lo = Id_Provincia_Pr " +
                             "WHERE Legajo_Me = '" + legajo + "'";
           
            return ds.ObtenerTabla("Medicos", consulta);
        }

    }

}












