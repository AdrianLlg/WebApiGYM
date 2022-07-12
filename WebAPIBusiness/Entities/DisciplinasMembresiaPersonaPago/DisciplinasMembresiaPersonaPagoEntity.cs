using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.DisciplinasMembresiaPersonaPago
{
    public class DisciplinasMembresiaPersonaPagoEntity
    {
        public int membresia_persona_disciplinaID { get; set; }
        public int disciplinaID { get; set; }
        public string nombreDisciplina { get; set; }
        public int numClasesDisponibles { get; set; }
        public int numClasesTomadas { get; set; }
    }
}
