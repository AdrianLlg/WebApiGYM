using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.EventoPersona.Models
{
    public class EventoPersonaDataRequest
    {
        public int flujoID { get; set; }
        public int evento_personaID { get; set; }
        public int eventoID { get; set; }
        public int personaID { get; set; }
        public int asistencia { get; set; }
        public string estadoRgistro { get; set; }
    }
}