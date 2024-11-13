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
    }



}

