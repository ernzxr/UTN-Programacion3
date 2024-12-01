using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Dao
{
    public class DaoUsuario
    {
        private AccesoDatos _accesoDatos = new AccesoDatos();
        public DaoUsuario() { }

        public Usuario ObtenerUsuarioPorCredenciales(string usuario, string contraseña)
        {

            // Consulta SQL para obtener el usuario, su clave y el tipo de usuario
            string query = @"
            SELECT u.Usuario_Us, u.Clave_Us, u.Id_Tipo_Usuario_Us, t.Id_Tipo_Usuario_TU
             FROM Usuarios u
            INNER JOIN Tipos_Usuarios t ON u.Id_Tipo_Usuario_Us = t.Id_Tipo_Usuario_TU
             WHERE u.Usuario_Us = @Usuario AND u.Clave_Us = @Contraseña";

            // Crear el comando con los parámetros
            SqlCommand comando = new SqlCommand(query);
            comando.Parameters.AddWithValue("@Usuario", usuario);
            comando.Parameters.AddWithValue("@Contraseña", contraseña);

            // Usamos el método ObtenerConexion() para obtener la conexión
            SqlConnection conexion = _accesoDatos.ObtenerConexion();
            if (conexion == null)
            {
                // Si no se pudo establecer la conexión, se maneja aquí
                return null;
            }

            // Asignar la conexión al comando
            comando.Connection = conexion;

            // Ejecutar la consulta
            try
            {
                DataTable dt = _accesoDatos.ObtenerTabla(comando); // Ejecutamos la consulta

                // Si se encuentra un usuario
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0]; // Tomamos la primera fila de los resultados
                    return new Usuario
                    {
                        Usuario_Us = row["Usuario_Us"].ToString(),
                        Clave_Us = row["Clave_Us"].ToString(),
                        IdTipoUsuario_Us = Convert.ToInt32(row["Id_Tipo_Usuario_Us"])
                    };
                }
            }
            finally
            {
                // Asegurarnos de cerrar la conexión después de usarla
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            // Si no se encontró el usuario
            return null;
        }


        public Boolean existeUsuario(string user)
        {
            string consulta = "SELECT * FROM Usuarios WHERE Usuario_Us = '" + user + "'";
            return _accesoDatos.existe(consulta);
        }

        public int agregarUsuario(Usuario user)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosAgregarUsuario(ref comando, user);
            return _accesoDatos.EjecutarProcedimientoAlmacenado(comando, "spAgregarUsuario");
        }

        private void ArmarParametrosAgregarUsuario(ref SqlCommand Comando, Usuario user)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@USUARIO", SqlDbType.VarChar, 50);
            SqlParametros.Value = user.GetUsuarioUs();
            SqlParametros = Comando.Parameters.Add("@CLAVE", SqlDbType.VarChar, 80);
            SqlParametros.Value = user.GetClaveUs();
            SqlParametros = Comando.Parameters.Add("@EMAIL", SqlDbType.VarChar, 100);
            SqlParametros.Value = user.GetEmailUs();
            SqlParametros = Comando.Parameters.Add("@TIPO", SqlDbType.Int);
            SqlParametros.Value = user.GetIdTipoUsuario();
        }

        private void ArmarParametrosNuevaClave(ref SqlCommand Comando, string usuario, string email, string nuevaClave)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Email", SqlDbType.VarChar, 100);
            SqlParametros.Value = email;
            SqlParametros = Comando.Parameters.Add("@Usuario", SqlDbType.VarChar, 50);
            SqlParametros.Value = usuario;
            SqlParametros = Comando.Parameters.Add("@NuevaClave", SqlDbType.VarChar, 80);
            SqlParametros.Value = nuevaClave;
        }

     
        
            public string VerificarYActualizarClave(string usuario, string email, string nuevaClave)
            {
                bool esValido = false;
                int tipoUsuario = -1;

                string consulta = @"
                    SELECT U.Usuario_Us, U.Email_Us, U.Id_Tipo_Usuario_Us
                    FROM Usuarios U
                    WHERE U.Usuario_Us = @Usuario AND U.Email_Us = @Email";

                using (SqlConnection conexion = _accesoDatos.ObtenerConexion())
                {
                    if (conexion == null)
                    {
                        // Si no se pudo obtener la conexión, simplemente retorna vacío o un valor de error controlado
                        return string.Empty; // O puedes retornar null o cualquier otro valor para indicar el error
                    }

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Usuario", usuario);
                        comando.Parameters.AddWithValue("@Email", email);

                        SqlDataReader reader = comando.ExecuteReader();
                        if (reader.Read())
                        {
                            string usuarioDB = reader.GetString(0);
                            string emailDB = reader.GetString(1);
                            tipoUsuario = reader.GetInt32(2);

                            // Verifica si las credenciales coinciden
                            if (usuarioDB.Equals(usuario, StringComparison.Ordinal) && emailDB.Equals(email, StringComparison.Ordinal))
                            {
                                esValido = tipoUsuario == 2; // Solo si el tipo de usuario es 2
                            }
                        }

                        reader.Close();
                    }
                }

                // Si es válido, actualiza la contraseña
                if (esValido)
                {
                    SqlCommand cmdActualizar = new SqlCommand();
                    ArmarParametrosNuevaClave(ref cmdActualizar, usuario, email, nuevaClave);

                    _accesoDatos.EjecutarProcedimientoAlmacenado(cmdActualizar, "ActualizarClave");
                return "Contraseña actualizada correctamente.";
            }

            // Si no es válido, retorna vacío o un valor que indique que la operación no fue exitosa

            return "El usuario o el email no están registrados o las credenciales no son correctas.";
        }


        public Boolean existeIdUsuario(int idUsuario)
        {
            string consulta = "SELECT * FROM Usuarios WHERE Id_Usuario_Us = '" + idUsuario + "'";
            return _accesoDatos.existe(consulta);
        }




    }
    }


