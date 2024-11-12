using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    { 
        public int IdUsuario_Us { get; set; } 
        public string Usuario_Us { get; set; } 
        public string Clave_Us { get; set; } 
        public string Email_Us { get; set; } 
        public int IdTipoUsuario_Us { get; set; } 

       public Usuario()
        {

        }

        public Usuario(int IdUsuario, string Usuario, string Clave, string Email, int IdTipoUsuario)
        {
            this.IdUsuario_Us = IdUsuario;
            this.Usuario_Us += Usuario_Us;  
            this.Clave_Us += Clave_Us;  
            this.Email_Us += Email_Us;
            this.IdTipoUsuario_Us = IdTipoUsuario;
        }


        public int GetIdUsuario()
        {
            return IdUsuario_Us;
        }

        public void SetIdUsuario(int idUsuario)
        {
            IdUsuario_Us = idUsuario;
        }

        public string GetUsuarioUs()
        {
            return Usuario_Us;
        }

        public void SetUsuarioUs(string usuarioUs)
        {
            Usuario_Us = usuarioUs;
        }

        public string GetClaveUs()
        {
            return Clave_Us;
        }

        public void SetClaveUs(string claveUs)
        {
            Clave_Us = claveUs;
        }

        public string GetEmailUs()
        {
            return Email_Us;
        }

        public void SetEmailUs(string emailUs)
        {
            Email_Us = emailUs;
        }

        public int GetIdTipoUsuario()
        {
            return IdTipoUsuario_Us;
        }

        public void SetIdTipoUsuario(int idTipoUsuario)
        {
            IdTipoUsuario_Us = idTipoUsuario;
        }

    }
}
