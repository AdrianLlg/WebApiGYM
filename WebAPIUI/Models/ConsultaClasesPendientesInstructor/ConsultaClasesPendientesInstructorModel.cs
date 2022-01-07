using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIUI.Models.ConsultaClasesPendientesInstructor
{
    public class ConsultaClasesPendientesInstructorModel
    {
        public int eventoID { get; set; }
        public string fecha { get; set; }
        public int horarioMID { get; set; }
        public string horario { get; set; }
        public int claseID { get; set; }
        public string nombreClase { get; set; }
        public int disciplinaID { get; set; }
        public string nombreDisciplina { get; set; }
        public int salaID { get; set; }
        public string nombreSala { get; set; }
        public int aforoMax { get; set; }
        public int aforoMin { get; set; }
        public int personaID { get; set; }
        public string estadoRegistro { get; set; }


    }
}
