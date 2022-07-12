using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIBusiness.Entities.EventoClasePersona;

namespace WebAPIBusiness.Entities.App.ConsultaEventosDeportista
{
    public class EventosDeportistaEntity
    {
        public int eventoID { get; set; }
        public string disciplina { get; set; }
        public string horaInicioEvento { get; set; }
        public string horaFinEvento { get; set; }
        public string fecha { get; set; }
        public string sala { get; set; }
        public int aforoMax { get; set; }
        public int aforoMin { get; set; }
        public int asistenciaEvento{ get; set; }
        public int asistenciaPersona { get; set; }
        public string estadoInscripcion { get; set; }
        public int instructorID { get; set; }
        public string nombreInstructor { get; set; }
        public int intentosCancelar { get; set; }
        public List<EventoClasePersonaRecursosEspecialesEntity> recursosEspeciales { get; set; }
        public int recursoEspecialPersona { get; set; }
    }
}
