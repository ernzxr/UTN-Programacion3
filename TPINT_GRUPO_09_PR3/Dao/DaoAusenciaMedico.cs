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
    public class DaoAusenciaMedico
    {
        AccesoDatos ds = new AccesoDatos();
        public AusenciaMedico getAusenciaMedico(AusenciaMedico ausMed)
        {
            DataTable tabla = ds.ObtenerTabla("Ausencias_Medicos",
            "SELECT Legajo_Medico_AM, TAM.Descripcion_TAM, " +
            "Fecha_Inicio_AM, Fecha_Fin_AM " +
            "FROM Ausencias_Medicos " +
            "INNER JOIN Tipo_Ausencias_Medicos AS TAM ON Id_Tipo_Ausencia_AM = TAM.Id_Tipo_Ausencia_TAM " +
            "WHERE Legajo_Medico=" + ausMed.getLegajoMedico());

            ausMed.setLegajoMedico((int)tabla.Rows[0][1]);
            ausMed.setTipoAusencia((int)tabla.Rows[0][2]);
            ausMed.setFechaInicio((DateTime)tabla.Rows[0][3]);
            ausMed.setFechaFin((DateTime)tabla.Rows[0][4]);
            return ausMed;
        }

        public Boolean existeAusencia(AusenciaMedico aus)
        {
            String consulta = "SELECT * FROM Ausencias_Medicos WHERE Legajo_Medico_AM='" + aus.getLegajoMedico() + "' AND Fecha_Inicio_AM='" + aus.getFechaInicio() + "'";
            return ds.existe(consulta);
        }

        public DataTable getTablaAusencias()
        {
            DataTable tabla = ds.ObtenerTabla("Ausencias_Medicos",
            "SELECT Legajo_Medico_AM, TAM.Descripcion_TAM, " +
            "Fecha_Inicio_AM, Fecha_Fin_AM " +
            "FROM Ausencias_Medicos " +
            "INNER JOIN Tipos_Ausencias_Medicos AS TAM ON Id_Tipo_Ausencia_AM = TAM.Id_Tipo_Ausencia_TAM ");
            return tabla;
        }

        public int agregarAusencia(AusenciaMedico aus)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosAgregarAusencia(ref comando, aus);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarAusencia");
        }

        private void ArmarParametrosAgregarAusencia(ref SqlCommand Comando, AusenciaMedico aus)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@LEGAJO", SqlDbType.Int);
            SqlParametros.Value = aus.getLegajoMedico();
            SqlParametros = Comando.Parameters.Add("@TIPO", SqlDbType.Int);
            SqlParametros.Value = aus.getTipoAusencia();
            SqlParametros = Comando.Parameters.Add("@FECHA_INICIO", SqlDbType.Date);
            SqlParametros.Value = aus.getFechaInicio();
            SqlParametros = Comando.Parameters.Add("@FECHA_FIN", SqlDbType.Date);
            SqlParametros.Value = aus.getFechaFin();
        }
    }
}
