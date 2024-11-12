using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DiaSemana
    {
        private int Id_Dia_Semana_DS;
        private string Descripcion_DS;

        public DiaSemana() { }

        public DiaSemana(int idDiaSemana, string descripcion)
        {
            this.Id_Dia_Semana_DS = idDiaSemana;
            this.Descripcion_DS = descripcion;
        }

        // Getters y Setters
        public int GetIdDiaSemana() { return Id_Dia_Semana_DS; }
        public void SetIdDiaSemana(int id) { Id_Dia_Semana_DS = id; }

        public string GetDescripcion() { return Descripcion_DS; }
        public void SetDescripcion(string desc) { Descripcion_DS = desc; }
    }
}
