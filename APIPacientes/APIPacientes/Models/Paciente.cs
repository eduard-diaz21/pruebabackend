using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPacientes.Models
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        public string nombreCompletoPaciente { get; set; }
        public string apellidoPaciente { get; set; }
        public string sexoPaciente { get; set; }
        public int edadPaciente { get; set; }
        public string correoPaciente { get; set; }
        public string tipoDocumentoPaciente { get; set; }
        public string documentoPaciente { get; set; }
        public string direccionPaciente { get; set; }
    }
}
