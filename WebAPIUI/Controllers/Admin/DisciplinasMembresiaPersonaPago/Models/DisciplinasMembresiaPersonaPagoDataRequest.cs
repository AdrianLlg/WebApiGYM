using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.DisciplinasMembresiaPersonaPago.Models
{
    public class DisciplinasMembresiaPersonaPagoDataRequest
    {
        public int flujoID { get; set; }
        public int membresia_persona_pagoID { get; set; }
        public int membresia_persona_disciplinaID { get; set; }
        public int numClasesDisponibles { get; set; }

    }
}