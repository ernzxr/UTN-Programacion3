using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Nacionalidad
    {
        private int Id_Nacionalidad_Na;
        private string Cod_Nacionalidad_Na;
        private string Descripcion_Na;

        public Nacionalidad()
        {

        }

        public Nacionalidad(int idNacionalidad, string codNacionalidad, string descripcion)
        {
            this.Id_Nacionalidad_Na = idNacionalidad;
            this.Cod_Nacionalidad_Na = codNacionalidad;
            this.Descripcion_Na = descripcion;
        }

        //Gets y Sets
        public int getIdNacionalidad() { return this.Id_Nacionalidad_Na; }
        public void setIdGenero(int IdNacionalidad) { this.Id_Nacionalidad_Na = IdNacionalidad; }


        public String getCodigoNacionalidad() { return this.Cod_Nacionalidad_Na; }
        public void setCodigoNacionalidad(string codNacionalidad) { this.Cod_Nacionalidad_Na = codNacionalidad; }

        public String getDescripcionNacionalidad() { return this.Descripcion_Na; }
        public void setDescripcionNacionalidad(string descripcion) { this.Descripcion_Na = descripcion; }
    }
}
