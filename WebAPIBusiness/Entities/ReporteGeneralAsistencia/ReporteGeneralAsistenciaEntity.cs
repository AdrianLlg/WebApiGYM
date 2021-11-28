using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WebAPIBusiness.Entities.ReporteGeneralAsistencia
{
    public class ReporteGeneralAsistenciaEntity
    {
        public string Persona { get; set; }
        public string Clase { get; set; }
        public string Disciplina { get; set; }
        public DateTime Fecha { get; set; }
        public string Asistencia { get; set; }

        public List<ReporteGeneralAsistenciaCAEntity> clasesAsistidas { get; set; }
        public List<ReporteGeneralAsistenciaCNAEntity> clasesNoAsistidas { get; set; }
    }
}



