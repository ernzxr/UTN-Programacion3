using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoAusencia
    {
        //Atributos
        private int IdTipoAusencia;
        private string CodTipoAusencia;
        private string Descripcion;

        //Constructor por defecto
        public TipoAusencia()
        {

        }

        //Constructor por parametro
        public TipoAusencia(int id, string cod, string des)
        {
            this.IdTipoAusencia = id;
            this.CodTipoAusencia = cod;
            this.Descripcion = des;
        }

        //Getters y Setters:
             public int getIdTipoAusencia()
        {
            return IdTipoAusencia;
        }

        public void setIdTipoAusencia(int id)
        {
            IdTipoAusencia = id;
        }

        public string getCodTipoAusencia()
        {
            return CodTipoAusencia;
        }

        public void setCodTipoAusencia(string cod)
        {
            CodTipoAusencia = cod;
        }

        public string getDescripcionTipoAusencia()
        {
            return Descripcion;
        }

        public void setDescripcionTipoAusencia(string des)
        {
            Descripcion = des;
        }
    }
}
