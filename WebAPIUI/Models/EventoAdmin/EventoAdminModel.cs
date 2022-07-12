using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Models.EventoAdmin
{
    public class EventoAdminModel
    {
        public int eventoID { get; set; }
        public string claseID { get; set; }
        public string horarioMID { get; set; }
        public string fecha { get; set; }
        public string salaID { get; set; }
        public string aforoMax { get; set; }
        public string aforoMin { get; set; }
        public string estadoRegistro { get; set; }
        public int personaID { get; set; }
        public string nombreProfesor { get; set; }
    }
}