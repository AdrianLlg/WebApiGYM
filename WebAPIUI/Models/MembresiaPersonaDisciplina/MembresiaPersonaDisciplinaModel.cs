using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Models.MembresiaPersonaDisciplina
{
    public class MembresiaPersonaDisciplinaModel
    {
        public int membresia_persona_disciplinaID { get; set; }
        public int personaID { get; set; }
        public int membresia_disciplinaID { get; set; }
        public string fechaPago { get; set; }
        public string fechaLimite { get; set; }
        public int numClasesDisponibles { get; set; }
        public string status { get; set; }
    }
}