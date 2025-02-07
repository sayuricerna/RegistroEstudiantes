using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudiantes.Models
{
    class inscripcion_model
    {
        //inscripion_model IdInscripcion IdCurso IdEstudiante Fecha
        public int IdInscripcion { get; set; }
        public int IdCurso { get; set; }
        public int IdEstudiante { get; set; }
        public DateTime Fecha { get; set; }

        public string NombreCurso { get; set; }
        public string NombreEstudiante { get; internal set; }
        public string ApellidoEstudiante { get; internal set; }
    }
}
