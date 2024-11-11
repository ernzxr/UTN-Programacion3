using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Especialidad
    {
        private int Id_Especialidad_Es;
        private string Cod_Especialidad_Es;
        private string Descripcion_Es;

        public Especialidad()
        {

        }

        public Especialidad(int idEspecialidad, string codEspecialidad, string descripcion)
        {
            this.Id_Especialidad_Es = idEspecialidad;
            this.Cod_Especialidad_Es = codEspecialidad;
            this.Descripcion_Es = descripcion;
        }

        //Gets y Sets
        public int getIdEspecialidad() { return this.Id_Especialidad_Es; }
        public void setIdEspecilidad(int IdEspecialidad) { this.Id_Especialidad_Es = IdEspecialidad; }

        public String getCodigoEspecialidad() { return this.Cod_Especialidad_Es; }
        public void setCodigoEspecialidad(String CodEspecialidad) { this.Cod_Especialidad_Es = CodEspecialidad; }

        public String getDescripcionEspecialidad() { return this.Descripcion_Es; }
        public void setDescripcionEspecialidad(String DescripcionEspecialidad) { this.Descripcion_Es = DescripcionEspecialidad; }
    }
}
