﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace TP6_GRUPO_09
{
    public class DML
    {
        Conexion cn = new Conexion();

        public DataTable ObtenerProductos()
        {
            string consultaSQL = "";
            string nombreTabla = "Productos";
            return cn.ObtenerTablas(consultaSQL, nombreTabla);
        }

        public int EliminarProducto(string idProducto)
        {
            string consultaSQL = "";
            return cn.EjecutarConsulta(consultaSQL);
        }
    }
}