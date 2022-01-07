using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.App.MembresiasPersona
{
    public class DisciplinasMembresiasPersonaEntity
    {
        public int disciplinaID { get; set; }
        public string nombreDisciplina { get; set; }
        public int numClases { get; set; }
        public int numClasesTomadas { get; set; }
    }
}
