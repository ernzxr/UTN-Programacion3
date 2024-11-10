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
    public class NegocioAusenciaMedico
    {
        DaoAusenciaMedico daoAusenciaMedico = new DaoAusenciaMedico();

        public bool AgregarAusencia(AusenciaMedico aus)
        {
            // validación si la sucursal ya existe
            if (daoAusenciaMedico.existeAusencia(aus))
            {
                return false;
            }

            // Llamar al método agregarSucursal de la capa de datos
            int filasAfectadas = daoAusenciaMedico.agregarAusencia(aus);

            return filasAfectadas > 0; // Si la inserción fue exitosa
        }

        public DataTable getAusencias()
        {
                return daoAusenciaMedico.getTablaAusencias();
        }
    }
}
