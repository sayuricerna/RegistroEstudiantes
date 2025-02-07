using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudiantes.Models
{
    class estudiante_model
    {
        //inscripcion_model IdEstudiante Nombre Apellido Edad Direccion
        public int IdEstudiante { get; set; }
        public string NombreEstudiante { get; set; }
        public string ApellidoEstudiante { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }

        public string NombreCompleto => $"{NombreEstudiante} {ApellidoEstudiante}";

    }
}
