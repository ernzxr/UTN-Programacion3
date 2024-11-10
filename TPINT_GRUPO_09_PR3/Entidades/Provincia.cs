using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Provincia
    {
        private int Id_Provincia_Pr;
        private string Cod_Provincia_Pr;
        private string Descripcion_Pr;

        public Provincia()
        {

        }

        public Provincia(int idProvincia, string codProvincia, string descripcion)
        {
            this.Id_Provincia_Pr = idProvincia;
            this.Cod_Provincia_Pr = codProvincia;
            this.Descripcion_Pr = descripcion;
        }

        //Gets y Sets
        public int getIdProvincia() { return this.Id_Provincia_Pr; }
        public void setIdProvincia(int IdProvincia) { this.Id_Provincia_Pr = IdProvincia; }

        public String getCodigoProvincia() { return this.Cod_Provincia_Pr; }
        public void setCodigoProvincia(String CodProvincia) { this.Cod_Provincia_Pr = CodProvincia; }

        public String getDescripcionProvincia() { return this.Descripcion_Pr; }
        public void setDescripcionProvincia(String DescripcionProvincia) { this.Descripcion_Pr = DescripcionProvincia; }
    }
}
