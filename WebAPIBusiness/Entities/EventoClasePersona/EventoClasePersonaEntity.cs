using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.EventoClasePersona
{
    public class EventoClasePersonaEntity
    {
        public int EventoID { get; set; }
        public string Clase { get; set; }
        public string NombreInstructor { get; set; }
        public string Descripcion { get; set; }
        public DateTime fecha { get; set; }
        public string horaInicio { get; set; }
        public string horaFin { get; set; }
        public int Asistentes { get; set; }
        public int AforoMaximoClase { get; set; }
        public int AforoMinimoClase { get; set; }
        public int ClaseAgendada { get; set; }
        public int recursosEspeciales { get; set; }

    }
}
