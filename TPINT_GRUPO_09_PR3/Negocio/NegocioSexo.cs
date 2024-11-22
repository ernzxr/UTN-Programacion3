using Dao;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioSexo
    {
        public NegocioSexo()
        {

        }

        public DataTable getTablaSexo()
        {
            DaoSexo dao = new DaoSexo();
            return dao.getSexo();
        }

        public string getDescripcionSexo(int idGenero)
        {
            string descripcionSexo = "";

            Genero genero = (Genero)idGenero;
            descripcionSexo = genero.ToString();

            return descripcionSexo.ToString();
        }

    }
}
