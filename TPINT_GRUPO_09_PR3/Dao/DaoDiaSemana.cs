using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
   public class DaoDiaSemana
   {
        AccesoDatos ds = new AccesoDatos();
        public DaoDiaSemana() { }

        public DataTable getDiaSemana()
        {
            string consulta = "SELECT * FROM Dias_Semanas";
            return ds.ObtenerTabla("Dias_Semanas", consulta);
        }

        public DiaSemana ObtenerDiaSemanaPorId(int id)
        {
            string consulta = "SELECT * FROM Dias_Semanas WHERE Id_Dia_Semana_DS = @Id";
            SqlCommand comando = new SqlCommand(consulta);
            comando.Parameters.AddWithValue("@Id", id);

            DataTable tabla = ds.ObtenerTabla(comando);
            if (tabla.Rows.Count > 0)
            {
                DiaSemana dia = new DiaSemana();
                dia.SetIdDiaSemana(Convert.ToInt32(tabla.Rows[0]["Id_Dia_Semana_DS"]));
                dia.SetDescripcion(tabla.Rows[0]["Descripcion_DS"].ToString());
                return dia;
            }
            return null;
        }

   }
}
