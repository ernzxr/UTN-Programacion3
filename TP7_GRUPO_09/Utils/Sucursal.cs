using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP6_GRUPO_09.Utils
{
    public class Sucursal
    {
        private int i_IdSucursal;
        private string s_NombreSucursal;
        private string s_DescripcionSucursal;
        private int i_IdProvincia;
        private string s_UrlImagenSucursal;

        //Constructor por defecto
        public Sucursal()
        {

        }

        //Constructor por parametro
        public Sucursal(int IdSucursal, string NombreSucursal, string descripcionSucursal, int IdProvincia, string UrlImagenSucursal)
        {
            this.i_IdSucursal = IdSucursal;
            this.s_NombreSucursal = NombreSucursal;
            this.s_DescripcionSucursal = descripcionSucursal;
            this.i_IdProvincia = IdProvincia;
            this.s_UrlImagenSucursal = UrlImagenSucursal;
        }

        //Gets y Sets
        public int IdSucursal
        {
            get { return i_IdSucursal; }
            set { i_IdSucursal = value; }
        }

        public string NombreSucursal
        {
            get { return s_NombreSucursal; }
            set { s_NombreSucursal = value; }
        }

        public int IdProvincia
        {
            get { return i_IdProvincia; }
            set { i_IdProvincia = value; }
        }

        public string DescripcionSucursal
        {
            get { return s_DescripcionSucursal; }
            set { s_DescripcionSucursal = value; }
        }
        public string UrlImagenSucursal
        {
            get { return s_UrlImagenSucursal; }
            set { s_UrlImagenSucursal = value; }
        }
    }
}