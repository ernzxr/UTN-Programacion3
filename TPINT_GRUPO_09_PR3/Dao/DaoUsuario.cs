﻿using System;
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

        public bool VerificarYActualizarClave(string usuario, string email, string nuevaClave)
        {
            // Consulta SQL para verificar si el usuario y el email existen en la base de datos
            string consulta = "SELECT COUNT(*) FROM Usuarios WHERE Usuario_Us = @Usuario AND Email_Us = @Email";

            // Crear el comando y agregar los parámetros
            SqlCommand comando = new SqlCommand(consulta);
            comando.Parameters.AddWithValue("@Usuario", usuario);
            comando.Parameters.AddWithValue("@Email", email);

            // Obtener la conexión
            SqlConnection conexion = _accesoDatos.ObtenerConexion();
            if (conexion == null)
            {
                // Si no se pudo establecer la conexión, retornamos false
                return false;
            }

            // Asignar la conexión al comando
            comando.Connection = conexion;

            // Ejecutar la consulta para verificar si existe el usuario y el email
            SqlDataReader reader = comando.ExecuteReader();

            bool existe = false;
            if (reader.Read() && reader.GetInt32(0) > 0)
            {
                existe = true; // Si el conteo es mayor a 0, el usuario y el email existen
            }

            // Cerrar la conexión y el lector
            conexion.Close();

            if (existe)
            {
                // Si el usuario y el email existen, se procede a cambiar la contraseña
                SqlCommand cmdActualizar = new SqlCommand("ActualizarClave", conexion);
                cmdActualizar.CommandType = CommandType.StoredProcedure;

                // Agregar los parámetros del procedimiento almacenado
                cmdActualizar.Parameters.AddWithValue("@Email", email);
                cmdActualizar.Parameters.AddWithValue("@Usuario", usuario);
                cmdActualizar.Parameters.AddWithValue("@NuevaClave", nuevaClave);

                // Ejecutar el procedimiento almacenado para actualizar la contraseña
                _accesoDatos.EjecutarProcedimientoAlmacenado(cmdActualizar, "ActualizarClave");

                return true; // Contraseña actualizada correctamente
            }

            return false; // Usuario o email no encontrados
        }



    }
}

