using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.App.ConsultaListaAsistencia
{
   public  class ConsultaListaAsistenciaEntity
    {
        public int eventoPersonaID { get; set; } 
        public int personaID { get; set; } 
        public int asistencia { get; set; }
        public string nombre { get; set; }
        public string identificacion { get; set; }

    }
}
