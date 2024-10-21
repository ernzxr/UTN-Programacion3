using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class DaoSucursal
    {
        AccesoDatos ds = new AccesoDatos();
        public Sucursal getSucursal(Sucursal suc)
        {
            DataTable tabla = ds.ObtenerTabla("Sucursal", "SELECT Id_Sucursal AS ID, NombreSucursal AS Nombre, DescripcionSucursal AS Descripcion, " +
                "DescripcionProvincia AS Provincia, DireccionSucursal AS Direccion FROM Sucursal INNER JOIN Provincia " +
                "ON Id_Provincia = Id_ProvinciaSucursal WHERE Id_Sucursal=" + suc.getIdSucursal());
            suc.setNombreSucursal(tabla.Rows[0][1].ToString());
            suc.setDescripcionSucursal(tabla.Rows[0][2].ToString());
            suc.setIdProvinciaSucursal((int)tabla.Rows[0][3]);
            suc.setDireccionSucursal(tabla.Rows[0][4].ToString());
            return suc;
        }

        public Boolean existeSucursal(Sucursal suc)
        {
            String consulta = "SELECT * FROM Sucursal WHERE NombreSucursal='" + suc.getNombreSucursal() + "'";
            return ds.existe(consulta);
        }

        public DataTable getTablaSucursales()
        {
            DataTable tabla = ds.ObtenerTabla("Sucursal", "SELECT Id_Sucursal AS ID, NombreSucursal AS Nombre, DescripcionSucursal AS Descripcion, " +
                "DescripcionProvincia AS Provincia, DireccionSucursal AS Direccion FROM Sucursal INNER JOIN Provincia " +
                "ON Id_Provincia = Id_ProvinciaSucursal");
            return tabla;
        }

        public int eliminarSucursal(Sucursal suc)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                ArmarParametrosSucursalEliminar(ref comando, suc);
                return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarSucursal");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void ArmarParametrosSucursalEliminar(ref SqlCommand Comando, Sucursal suc)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Id_Sucursal", SqlDbType.Int);
            SqlParametros.Value = suc.getIdSucursal();
        }
        public int agregarSucursal(Sucursal suc)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosSucursalAgregar(ref comando, suc);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarSucursal");
        }

        private void ArmarParametrosSucursalAgregar(ref SqlCommand Comando, Sucursal suc)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@NOMBRESUCURSAL", SqlDbType.VarChar);
            SqlParametros.Value = suc.getNombreSucursal();
            SqlParametros = Comando.Parameters.Add("@DESCRIPCIONSUCURSAL", SqlDbType.VarChar);
            SqlParametros.Value = suc.getDescripcionSucursal();
            SqlParametros = Comando.Parameters.Add("@IDPROVINCIASUCURSAL", SqlDbType.Int);
            SqlParametros.Value = suc.getIdProvinciaSucursal();
            SqlParametros = Comando.Parameters.Add("@DIRECCIONSUCURSAL", SqlDbType.VarChar);
            SqlParametros.Value = suc.getDireccionSucursal();
        }

        public DataTable getTablaSucursalesFiltrada(int id)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosTablaSucursalesFiltrada(ref comando, id);
            return ds.EjecutarProcedimientoAlmacenadoLectura(comando, "spFiltrarSucursales");
        }

        private void ArmarParametrosTablaSucursalesFiltrada(ref SqlCommand Comando, int id)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Id_Sucursal", SqlDbType.Int);
            SqlParametros.Value = id;
        }
    }
}
