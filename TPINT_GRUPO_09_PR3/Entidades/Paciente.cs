using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente
    {
        private string Dni_Pa;
        private string Nombre_Pa;
        private string Apellido_Pa;
        private int Id_Genero_Pa;
        private DateTime Fecha_Nacimiento_Pa;
        private int Id_Nacionalidad_Pa;
        private int Id_Localidad_Pa;
        private string Direccion_Pa;
        private string Email_Pa;
        private string Telefono_Pa;
        private Boolean Estado_Pa;

        public Paciente()
        {

        }

        public Paciente(string dni_Pa, string nombre_Pa, string apellido_Pa, int id_Genero_Pa, DateTime fecha_Nacimiento_Pa, int id_Nacionalidad_Pa, int id_Localidad_Pa, string direccion_Pa, string email_Pa, string telefono_Pa, bool estado_Pa)
        {
            this.Dni_Pa = dni_Pa;
            this.Nombre_Pa = nombre_Pa;
            this.Apellido_Pa = apellido_Pa;
            this.Id_Genero_Pa = id_Genero_Pa;
            this.Fecha_Nacimiento_Pa = fecha_Nacimiento_Pa;
            this.Id_Nacionalidad_Pa = id_Nacionalidad_Pa;
            this.Id_Localidad_Pa = id_Localidad_Pa;
            this.Direccion_Pa = direccion_Pa;
            this.Email_Pa = email_Pa;
            this.Telefono_Pa = telefono_Pa;
            this.Estado_Pa = estado_Pa;
        }

        public string getDni() { return this.Dni_Pa; }
        public void setDni(string dni) { this.Dni_Pa = dni; }

        public string getNombre() { return this.Nombre_Pa; }
        public void setNombre(string nombre) { this.Nombre_Pa = nombre; }

        public string getApellido() { return this.Apellido_Pa; }
        public void setApellido(string apellido) { this.Apellido_Pa = apellido; }

        public int getGenero() { return this.Id_Genero_Pa; }
        public void setGenero(int genero) { this.Id_Genero_Pa = genero; }

        public DateTime getFechaNacimiento() { return this.Fecha_Nacimiento_Pa; }
        public void setFechaNacimiento(DateTime fecha) { this.Fecha_Nacimiento_Pa = fecha; }

        public int getNacionalidad() { return this.Id_Nacionalidad_Pa; }
        public void setNacionalidad(int nacionalidad) { this.Id_Nacionalidad_Pa = nacionalidad; }

        public int getLocalidad() { return this.Id_Localidad_Pa; }
        public void setLocalidad(int localidad) { this.Id_Localidad_Pa = localidad; }

        public string getDireccion() { return this.Direccion_Pa; }
        public void setDireccion(string direccion) { this.Direccion_Pa = direccion; }

        public string getEmail() { return this.Email_Pa; }
        public void setEmail(string email) { this.Email_Pa = email; }

        public string getTelefono() { return this.Telefono_Pa; }
        public void setTelefono(string telefono) { this.Telefono_Pa = telefono; }

        public Boolean getEstado() { return this.Estado_Pa; }
        public void setEstado(Boolean estado) { this.Estado_Pa = estado; }
    }
}
