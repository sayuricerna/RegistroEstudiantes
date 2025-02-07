using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudiantes.Models
{
    class curso_model
    {
        //curso_model IdCurso Nombre Creditos Profesor
        public int IdCurso { get; set; }
        public string NombreCurso { get; set; }
        public int Creditos { get; set; }
        public string Profesor { get; set; }

    }
}
