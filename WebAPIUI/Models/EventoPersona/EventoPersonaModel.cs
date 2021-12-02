using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Models.EventoPersona
{
    public class EventoPersonaModel
    {
        public int evento_personaID { get; set; }
        public int eventoID { get; set; }
        public int personaID { get; set; }
        public int asistencia { get; set; }
    }
}