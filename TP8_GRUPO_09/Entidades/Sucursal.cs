using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sucursal
    {
        //Atributos
        private int Id_Sucursal;
        private string NombreSucursal;
        private string DescripcionSucursal;
        private int Id_ProvinciaSucursal;
        private string DireccionSucursal;

        //Constructor por defecto
        public Sucursal()
        {

        }

        //Constructor por parametro
        public Sucursal(int idSuc, string nombre, string descripcion,
                        string direccion, int idProv)
        {
            this.Id_Sucursal = idSuc;
            this.NombreSucursal = nombre;
            this.DescripcionSucursal = descripcion;
            this.Id_ProvinciaSucursal = idProv;
        }

        //Gets y Sets:
        //ID SUCURSAL
        public int getIdSucursal()
        {
            return Id_Sucursal;
        }
        public void setIdSucursal(int IdSucursal)
        {
            Id_Sucursal = IdSucursal;
        }

        //NOMBRE SUCURSAL
        public String getNombreSucursal()
        {
            return NombreSucursal;
        }
        public void setNombreSucursal(String ns)
        {
            NombreSucursal = ns;
        }

        //DESCRIPCION SUCURSAL
        public String getDescripcionSucursal()
        {
            return DireccionSucursal;
        }
        public void setDescripcionSucursal(String ds)
        {
            DireccionSucursal = ds;
        }

        //ID PROVINCIA SUCURSAL
        public int getIdProvinciaSucursal()
        {
            return Id_ProvinciaSucursal;
        }
        public void setIdProvinciaSucursal(int IdProvinciaSucursal)
        {
            Id_ProvinciaSucursal = IdProvinciaSucursal;
        }

        //DIRECCION SUCURSAL
        public String getDireccionSucursal()
        {
            return DireccionSucursal;
        }
        public void setDireccionSucursal(String ds)
        {
            DireccionSucursal = ds;
        }
    }
}
