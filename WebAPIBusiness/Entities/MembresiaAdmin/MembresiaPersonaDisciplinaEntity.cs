using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIData;

namespace WebAPIBusiness.Entities.MembresiaAdmin
{
    public class MembresiaPersonaDisciplinaEntity
    {
        public int membresia_persona_disciplinaID { get; set; }
        public int membresia_persona_pagoID { get; set; }
        public int personaID { get; set; }
        public int membresia_disciplinaID { get; set; }
        public Nullable<System.DateTime> fechaInicio { get; set; }
        public System.DateTime fechaFin { get; set; }
        public int numClasesDisponibles { get; set; }
        public int numClasesTomadas { get; set; }

        public string estado { get; set; } 

    }
}
