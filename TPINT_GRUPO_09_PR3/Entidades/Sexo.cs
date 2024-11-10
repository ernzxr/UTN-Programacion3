using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sexo
    {
        private int Id_Genero_Ge;
        private string Cod_Genero_Ge;
        private string Descripcion_Ge;

        public Sexo()
        {

        }

        public Sexo(int idGenero, string codGenero, string descripcion)
        {
            this.Id_Genero_Ge = idGenero;
            this.Cod_Genero_Ge = codGenero;
            this.Descripcion_Ge = descripcion;
        }

        //Gets y Sets
        public int getIdGenero() { return this.Id_Genero_Ge; }
        public void setIdGenero(int IdGenero) { this.Id_Genero_Ge = IdGenero; }


        public String getCodGenero() { return this.Cod_Genero_Ge; }
        public void setCodigoGenero(String codGenero) { this.Cod_Genero_Ge = codGenero; }

        public String getDescripcionSexo() { return this.Descripcion_Ge; }
        public void setDescripcionSexo(String descripcion) { this.Descripcion_Ge = descripcion; }
    }
}
