using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.MembresiaPersonaDisciplina.Models
{
    public class MembresiaPersonaDisciplinaDataRequest
    {
        public int flujoID { get; set; }
        public int membresia_persona_disciplinaID { get; set; }
        public int membresia_persona_pagoID { get; set; }
        public int personaID { get; set; }
        public int membresia_disciplinaID { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public int numClasesDisponibles { get; set; }
        public int numClasesTomadas { get; set; }

        public string estado { get; set; }

    }
} 