﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades;

 
namespace Negocio
{
    public class NegocioUsuario
    {
       DaoUsuario _daoUsuario = new DaoUsuario(); // Accedemos al DaoUsuario

        public string VerificarUsuario(string usuario, string contraseña)
        {
            Usuario usuarioDB = _daoUsuario.ObtenerUsuarioPorCredenciales(usuario, contraseña);

            if (usuarioDB != null)
            {
                if (!usuarioDB.Usuario_Us.Equals(usuario, StringComparison.Ordinal))
                {
                    return "Credenciales incorrectas";
                }

                if (usuarioDB.IdTipoUsuario_Us == 1)
                    return "Administrador";
                else if (usuarioDB.IdTipoUsuario_Us == 2)
                    return "Médico";
            }

            return "Credenciales incorrectas";
        }

        public Boolean existeUsuario(string user)
        {
            return _daoUsuario.existeUsuario(user);
        }

        public Boolean agregarUsuario(Usuario usuario)
        {
            if(_daoUsuario.existeUsuario(usuario.GetUsuarioUs()))
            {
                return false; // Si el usuario ya existe
            }

            int filasAfectadas = _daoUsuario.agregarUsuario(usuario); ;

            return filasAfectadas > 0; // Si la inserción fue exitosa

        }

        public string CambiarContraseña(string usuario, string email, string nuevaClave)
        {
            string resultado = _daoUsuario.VerificarYActualizarClave(usuario, email, nuevaClave);
            return resultado; 
        }

        public Boolean existeIdUsuario(int idUsuario)
        {
            return _daoUsuario.existeIdUsuario(idUsuario);
        }

        public bool existeNombreUsuario(string usuario)
        {
            return _daoUsuario.existeUsuario(usuario);
        }

        
        public bool existeEmail(string email)
        {
            // Llamar al método de la capa de negocio o DAO para verificar si el email existe
            return _daoUsuario.existeEmail(email);
        }
        public bool modificarUsuario(Usuario user)
        {
            int resultado = _daoUsuario.modificarUsuario(user); // Aquí sigue retornando int desde el DAO
            return resultado > 0; // Si es mayor que 0, la operación fue exitosa
        }


    }


}




