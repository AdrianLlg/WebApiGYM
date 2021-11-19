using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIData;

namespace WebAPIBusiness.Entities.Membresia
{
    public class MembresiaEntity
    {
        public string nombreMembresia { get; set; }
        public decimal precioMembresia { get; set; }

        public string periodicidadMembresia { get; set; }
        public List<membresia_persona_disciplina> disciplinasmembresia { get; set; }
        public DateTime fechaPago { get; set; }
        public DateTime fechaLimite { get; set; }
    }
}
