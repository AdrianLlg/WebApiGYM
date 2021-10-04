using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.EventoRecurso
{
    public class EventoRecursoEntity
    {
        public int evento_recursoID { get; set; }
        public int eventoID { get; set; }
        public int recursoID { get; set; }
        public int statusReserva { get; set; }
        public int personaID { get; set; }
    }
}
