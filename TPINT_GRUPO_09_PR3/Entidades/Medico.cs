using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Medico
    {
        private string Legajo_Me;
        private int Id_Localidad_Me;
        private int Id_Especialidad_Me;
        private int Id_Nacionalidad_Me;
        private int Id_Genero_Me;
        private string Usuario_Me;
        private string DNI_Me;
        private string Email_Me;
        private string Nombre_Me;
        private string Apellido_Me;
        private DateTime Fecha_Nacimiento_Me;
        private string Direccion_Me;
        private string Telefono_Me;
        private bool Estado_Me;


        public Medico()
        {

        }

        public Medico(string legajo, int idLocalidad, int idEspecialidad, int idNacionalidad, int idGenero, string usuario, string dni, string email,
                         string nombre, string apellido, DateTime fechaNacimiento, string direccion, string telefono)
        {
            this.Legajo_Me = legajo;
            this.Id_Localidad_Me = idLocalidad;
            this.Id_Especialidad_Me = idEspecialidad;
            this.Id_Nacionalidad_Me = idNacionalidad;
            this.Id_Genero_Me = idGenero;
            this.Usuario_Me = usuario;
            this.DNI_Me = dni;
            this.Email_Me = email;
            this.Nombre_Me = nombre;
            this.Apellido_Me = apellido;
            this.Fecha_Nacimiento_Me = fechaNacimiento;
            this.Direccion_Me = direccion;
            this.Telefono_Me = telefono;
        }

        //Gets y Sets

        public string getLegajo() { return this.Legajo_Me; }

        public int getIdLocalidad() { return this.Id_Localidad_Me; }

        public int getIdEspecialidad() { return this.Id_Especialidad_Me; }

        public int getNacionalidad() { return this.Id_Nacionalidad_Me; }

        public int getGenero() { return this.Id_Genero_Me; }

        public string getUsuario() { return this.Usuario_Me; }

        public string getDni() { return this.DNI_Me; }

        public string getEmail() { return this.Email_Me; }

        public string getNombre() { return this.Nombre_Me; }

        public string getApellido() { return this.Apellido_Me; }

        public DateTime getFechaNacimiento() { return this.Fecha_Nacimiento_Me; }

        public string getDireccion() { return this.Direccion_Me; }

        public string getTelefono() { return this.Telefono_Me; }

        public bool getEstado() { return this.Estado_Me; }

        public void setIdLocalidad(int IdLocalidad) { this.Id_Localidad_Me = IdLocalidad; }

        public void setIdEspecilidad(int IdEspecialidad) { this.Id_Especialidad_Me = IdEspecialidad; }

        public void setIdNacionalidad(int IdNacionalidad) { this.Id_Nacionalidad_Me = IdNacionalidad; }

        public void setIdGenero(int IdGenero) { this.Id_Genero_Me = IdGenero; }

        public void setUsuario(string Usuario) { this.Usuario_Me = Usuario; }

        public void setDni(string Dni) { this.DNI_Me = Dni; }

        public void setNombre(string Nombre) { this.Nombre_Me = Nombre; }

        public void setApellido(string Apellido) { this.Apellido_Me = Apellido; }

        public void setFechaNacimiento(DateTime FechaNacimiento) { this.Fecha_Nacimiento_Me = FechaNacimiento; }

        public void setDireccion(string Direccion) { this.Direccion_Me = Direccion; }

        public void setTelefono(string Telefono) { this.Telefono_Me = Telefono; }

        public void setLegajo(string Legajo) { this.Legajo_Me = Legajo; }

        public void setEmail(string eMail) { this.Email_Me = eMail; }

        public void setEstado(bool estado) { this.Estado_Me = estado; }
    }
}
