using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Dao
{
    public class DaoAusenciasMedico
    {
        AccesoDatos ds = new AccesoDatos();
        public AusenciasMedico getAusenciasMedico(AusenciasMedico ausMed)
        {
            DataTable tabla = ds.ObtenerTabla("Ausencias_Medicos",
            "SELECT Legajo_Medico_AM AS Legajo, TAM.Descripcion_TAM AS [Razon Ausencia], " +
            "Fecha_Inicio_AM AS [Fecha Inicio], Fecha_Fin_AM AS [Fecha Fin] " +
            "FROM Ausencias_Medicos " +
            "INNER JOIN Tipo_Ausencias_Medicos AS TAM ON Id_Tipo_Ausencia_AM = TAM.Id_Tipo_Ausencia_TAM " +
            "WHERE Legajo_Medico=" + ausMed.getLegajoMedico());

            ausMed.setLegajoMedico((int)tabla.Rows[0][1]);
            ausMed.setTipoAusencia((int)tabla.Rows[0][2]);
            ausMed.setFechaInicio((DateTime)tabla.Rows[0][3]);
            ausMed.setFechaFin((DateTime)tabla.Rows[0][4]);
            return ausMed;
        }
    }
}
