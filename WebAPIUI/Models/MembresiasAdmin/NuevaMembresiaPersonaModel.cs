using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Models.MembresiasAdmin
{
    public class NuevaMembresiaPersonaModel
    {

        public int membresia_persona_disciplinaID { get; set; }
        public int membresiaID { get; set; }
        public int personaID { get; set; }
        public string fechaPago { get; set; }
        public string fechaLimite { get; set; }
        public string statusMembresia { get; set; }
    }
}