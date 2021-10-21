using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.Membresia
{
    public class MembresiaEntity
    {
        public string nombreMembresia { get; set; }
        public int precioMembresia { get; set; }
        public string nombreDisciplina { get; set; }
        public DateTime fechaPago { get; set; }
        public DateTime fechaLimite { get; set; }
        public int numClasesDisponibles { get; set; }

    }
}
