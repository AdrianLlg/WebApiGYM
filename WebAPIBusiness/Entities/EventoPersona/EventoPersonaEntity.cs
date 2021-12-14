using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.EventoPersona
{
    public class EventoPersonaEntity
    {
        public int evento_personaID { get; set; }
        public int eventoID { get; set; }
        public int personaID { get; set; }
        public int asistencia { get; set; }
        public string estadoRegistro { get; set; }
    }
}
