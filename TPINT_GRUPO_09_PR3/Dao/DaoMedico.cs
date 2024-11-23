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

        public Boolean existeLegajo(string legajo)
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
        public (string legajo, string nombre, string apellido, string dni, DateTime fechaNacimiento, string direccion, string telefono, string email,
        string nombreEspecialidad, string nombreLocalidad, string nombreProvincia, string nombreNacionalidad) ObtenerDatosMedicoPorUsuario(string usuario)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand(
                    "SELECT * FROM Medicos WHERE Usuario_Me = @Usuario AND Estado_Me = 1",
                    conexion);

                comando.Parameters.AddWithValue("@Usuario", usuario);

                try
                {
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        // Recuperar los datos directamente en variables
                        string legajo = reader["Legajo_Me"].ToString();
                        string nombre = reader["Nombre_Me"].ToString();
                        string apellido = reader["Apellido_Me"].ToString();
                        string dni = reader["DNI_Me"].ToString();
                        DateTime fechaNacimiento = default(DateTime); // Inicializar como valor por defecto

                        if (reader["Fecha_Nacimiento_Me"] != DBNull.Value)
                        {
                            fechaNacimiento = Convert.ToDateTime(reader["Fecha_Nacimiento_Me"]);
                        }
                        string direccion = reader["Direccion_Me"].ToString();
                        string telefono = reader["Telefono_Me"].ToString();
                        string email = reader["Email_Me"].ToString();
                        int idLocalidad = Convert.ToInt32(reader["Id_Localidad_Me"]);
                        int idEspecialidad = Convert.ToInt32(reader["Id_Especialidad_Me"]);
                        int idNacionalidad = Convert.ToInt32(reader["Id_Nacionalidad_Me"]);

                        // Obtener los datos relacionados usando los métodos auxiliares
                        string nombreEspecialidad = ObtenerNombreEspecialidad(idEspecialidad);
                        string nombreLocalidad = ObtenerNombreLocalidad(idLocalidad);
                        string nombreProvincia = ObtenerNombreProvincia(idLocalidad);
                        string nombreNacionalidad = ObtenerNombreNacionalidad(idNacionalidad);

                        // Retornar todos los datos en una tupla
                        return (legajo, nombre, apellido, dni, fechaNacimiento, direccion, telefono, email,
                                nombreEspecialidad, nombreLocalidad, nombreProvincia, nombreNacionalidad);
                    }
                    else
                    {
                        return (null, null, null, null, default, null, null, null, null, null, null, null);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los datos del médico: " + ex.Message);
                }
            }
        }

        public string ObtenerNombreLocalidad(int idLocalidad)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand(
                    "SELECT Descripcion_Lo FROM Localidades WHERE Id_Localidad_Lo = @IdLocalidad",
                    conexion);

                comando.Parameters.AddWithValue("@IdLocalidad", idLocalidad);

                try
                {
                    conexion.Open();
                    object resultado = comando.ExecuteScalar();
                    return resultado != null ? resultado.ToString() : null;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el nombre de la localidad: " + ex.Message);
                }
            }
        }

        public string ObtenerNombreProvincia(int idLocalidad)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand(
                    "SELECT p.Descripcion_Pr FROM Localidades l " +
                    "INNER JOIN Provincias p ON l.Id_Provincia_Lo = p.Id_Provincia_Pr " +
                    "WHERE l.Id_Localidad_Lo = @IdLocalidad",
                    conexion);

                comando.Parameters.AddWithValue("@IdLocalidad", idLocalidad);

                try
                {
                    conexion.Open();
                    object resultado = comando.ExecuteScalar();
                    return resultado != null ? resultado.ToString() : null;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el nombre de la provincia: " + ex.Message);
                }
            }
        }

        public string ObtenerNombreNacionalidad(int idNacionalidad)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand(
                    "SELECT Descripcion_Na FROM Nacionalidades WHERE Id_Nacionalidad_Na = @IdNacionalidad",
                    conexion);

                comando.Parameters.AddWithValue("@IdNacionalidad", idNacionalidad);

                try
                {
                    conexion.Open();
                    object resultado = comando.ExecuteScalar();
                    return resultado != null ? resultado.ToString() : null;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el nombre de la nacionalidad: " + ex.Message);
                }
            }
        }
        public string ObtenerNombreEspecialidad(int idEspecialidad)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand(
                    "SELECT Descripcion_Es FROM Especialidades WHERE Id_Especialidad_Es = @Id",
                    conexion);
                comando.Parameters.AddWithValue("@Id", idEspecialidad);

                conexion.Open();
                return comando.ExecuteScalar()?.ToString() ?? "Desconocida";
            }
        }

    }
}

      

    


















