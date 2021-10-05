using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.EventoClasePersona.Models
{
    public class EventoClasePersonaRequest
    {
        public string personaID { get; set; }
        public string fechaEvento { get; set; }
    }
}