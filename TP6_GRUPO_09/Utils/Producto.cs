using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP6_GRUPO_09.Utils
{
    public class Producto
    {
        private int i_IdProducto;
        private string s_NombreProducto;
        private string s_CantidadPorUnidad;
        private decimal d_PrecioUnidad;

        //Constructor por defecto
        public Producto()
        {

        }

        //Constructor por parametro
        public Producto(int IdProducto, string NombreProducto, string CantidadPorUnidad, decimal PrecioUnidad)
        {
            this.i_IdProducto = IdProducto;
            this.s_NombreProducto = NombreProducto;
            this.s_CantidadPorUnidad = CantidadPorUnidad;
            this.d_PrecioUnidad = PrecioUnidad;
        }

        //Gets y Sets
        public int IdProducto
        {
            get { return i_IdProducto; }
            set { i_IdProducto = value; }
        }

        public string NombreProducto
        {
            get { return s_NombreProducto; }
            set { s_NombreProducto = value; }
        }

        public string CantidadPorUnidad
        {
            get { return s_CantidadPorUnidad; }
            set { s_CantidadPorUnidad = value; }
        }

        public decimal PrecioUnidad
        {
            get { return d_PrecioUnidad; }
            set { d_PrecioUnidad = value; }
        }
    }
}