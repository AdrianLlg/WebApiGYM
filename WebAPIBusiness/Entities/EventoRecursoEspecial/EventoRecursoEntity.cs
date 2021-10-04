using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.EventoRecursoEspecial
{
    public class EventoRecursoEspecialEntity
    {
        public int evento_recursoEspecialID { get; set; }
        public int eventoID { get; set; }
        public int recursoEspecialID { get; set; }
        public int personaID { get; set; }

    }
}
