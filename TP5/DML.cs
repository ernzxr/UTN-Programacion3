using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace TP5
{
    public class DML
    {
        Conexion cn = new Conexion();

        public DataTable ObtenerSucursales()
        {
            string consultaSQL = "SELECT Id_Sucursal AS ID, NombreSucursal AS Nombre, DescripcionSucursal AS Descripción, DescripcionProvincia AS Provincia, DireccionSucursal AS Dirección " +
                "FROM Sucursal INNER JOIN Provincia ON Id_Provincia=Id_ProvinciaSucursal";
            string nombreTabla = "Sucursales";
            return cn.ObtenerTablas(consultaSQL, nombreTabla);
        }

        public DataTable ObtenerProvincias()
        {
            string consultaSQL = "SELECT * FROM Provincia";
            string nombreTabla = "Provincias";
            return cn.ObtenerTablas(consultaSQL, nombreTabla);
        }

        public int AgregarSucursal(string nombre, string descripcion, string idProvincia, string direccion)
        {
            string consultaSQL = "INSERT INTO Sucursal (NombreSucursal, DescripcionSucursal, Id_ProvinciaSucursal, DireccionSucursal) " +
                                 $"VALUES ('{nombre}', '{descripcion}', '{idProvincia}', '{direccion}')";
            return cn.EjecutarConsulta(consultaSQL);
        }

        public int EliminarSucursal(string idSucursal)
        {
            string consultaSQL = "DELETE FROM Sucursal " +
                $"WHERE Id_Sucursal='{idSucursal}'";
            return cn.EjecutarConsulta(consultaSQL);
        }

        public DataTable BuscarSucursal(string idSucursal)
        {
            string consultaSQL = "SELECT Id_Sucursal AS ID, NombreSucursal AS Nombre, DescripcionSucursal AS Descripción, DescripcionProvincia AS Provincia, DireccionSucursal AS Dirección " +
                "FROM Sucursal INNER JOIN Provincia ON Id_Provincia=Id_ProvinciaSucursal " +
                $"WHERE Id_Sucursal='{idSucursal}'";
            string nombreTabla = "Sucursales";
            return cn.ObtenerTablas(consultaSQL, nombreTabla);
        }
    }
}