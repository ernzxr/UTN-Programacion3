using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Provincia
    {
        private int i_IdProvincia;
        private String s_DescripcionProvincia;

        public Provincia() { }

        public Provincia(int i_IdProvincia, String s_DescripcionProvincia)
        {
            this.i_IdProvincia = i_IdProvincia;
            this.s_DescripcionProvincia = s_DescripcionProvincia;
        }

        public int getIdProvincia()
        {
            return i_IdProvincia;
        }

        public void setIdProvincia(int idProvincia)
        {
            i_IdProvincia = idProvincia;
        }

        public String getDescripcionProvincia()
        {
            return s_DescripcionProvincia;
        }

        public void setDescripcionProvincia(String descripcionProvincia)
        {
            s_DescripcionProvincia = descripcionProvincia;
        }
    }
}
