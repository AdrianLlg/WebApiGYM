using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIUI.Models.Fichas
{
    public class FichaPersonaModel
    {
        public int fichaPersonaID { get; set; }
        public int PersonaID { get; set; }
        public string MesoTipo { get; set; }
        public string NivelActualActividadFisica { get; set; }
        public string AntecendesMedicos { get; set; }
        public string Alergias { get; set; }
        public string Enfermedades { get; set; }
    }
}
