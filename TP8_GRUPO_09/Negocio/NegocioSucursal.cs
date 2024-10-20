using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Dao;

namespace Negocio
{
    public class NegocioSucursal
    {
        DaoSucursal daoSucursal = new DaoSucursal();

        public bool AgregarSucursal(Sucursal sucursal)
        {
            // validaciones de negocio
            if (string.IsNullOrEmpty(sucursal.getNombreSucursal()))
            {
                throw new Exception("El nombre de la sucursal es obligatorio.");
            }

            // validación si la sucursal ya existe
            if (daoSucursal.existeSucursal(sucursal))
            {
                throw new Exception("La sucursal ya existe.");
            }

            // Llamar al método agregarSucursal de la capa de datos
            int filasAfectadas = daoSucursal.agregarSucursal(sucursal);

            return filasAfectadas > 0; // Si la inserción fue exitosa
        }
    }
}
