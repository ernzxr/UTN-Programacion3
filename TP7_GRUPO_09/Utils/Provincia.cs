using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP7_GRUPO_09.Utils
{
    public class Provincia
    {
        private int i_IdProvincia;
        private string s_DescripicionProvincia;
        public Provincia() {

        }
        public Provincia(int idProvincia, string DescripcionProvincia) {
            this.i_IdProvincia = idProvincia;
            this.s_DescripicionProvincia = DescripcionProvincia;
        }

        public int IdProvincia
        {
            get { return i_IdProvincia; }
            set { i_IdProvincia = value; }
        }

        public string DescripicionProvincia
        {
            get { return s_DescripicionProvincia; }
            set { s_DescripicionProvincia = value; }
        }
    }
}