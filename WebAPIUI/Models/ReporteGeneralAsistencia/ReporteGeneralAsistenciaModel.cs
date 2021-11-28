using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WebAPIUI.Models.ReporteGeneralAsistencia
{
    public class ReporteGeneralAsistenciaModel
    {
        public string Persona { get; set; }
        public string Clase { get; set; }
        public string Disciplina { get; set; }
        public DateTime Fecha { get; set; }
        public string Asistencia { get; set; }

        public List<ReporteGeneralAsistenciaCAModel> clasesAsistidas { get; set; } 
        public List<ReporteGeneralAsistenciaCNAModel> clasesNoAsistidas { get; set; }
    }
}



