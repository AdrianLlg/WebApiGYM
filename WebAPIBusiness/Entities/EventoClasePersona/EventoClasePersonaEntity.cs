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
        public string Disciplina { get; set; }
        public string Sala { get; set; }
        public string NombreInstructor { get; set; }
        public string Descripcion { get; set; }
        public string fecha { get; set; }
        public string horaInicio { get; set; }
        public string horaFin { get; set; }
        public int Asistentes { get; set; }
        public int AforoMaximoClase { get; set; }
        public int AforoMinimoClase { get; set; }

        public string recursoEspecial { get; set; }

    }
}
