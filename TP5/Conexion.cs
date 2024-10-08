﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace TP5
{
    public class Conexion
    {
        private static string rutaConexion = "Data Source=localhost\\sqlexpress; Initial Catalog=BDSucursales; Integrated Security=True";
        private SqlConnection cn = new SqlConnection(rutaConexion);

        public DataTable ObtenerTablas(string consultaSQL, string nombreTabla)
        {
            cn.Open();
            SqlDataAdapter adap = new SqlDataAdapter(consultaSQL, cn);
            DataSet ds = new DataSet();
            adap.Fill(ds, nombreTabla);
            cn.Close();
            return ds.Tables[nombreTabla];
        }

        public int EjecutarConsulta(string consultaSQL)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand(consultaSQL, cn);
            int filas = (int)cmd.ExecuteNonQuery();
            cn.Close();
            return filas;
        }
    }
}