using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.Membresia
{
    public class MembresiaEntity
    {
        public int disciplinaID { get; set; }
        public string nombreDisciplina { get; set; }
        public decimal precio { get; set; }
        public int numClasesDisponibles { get; set; }
        //public DateTime fechaPago { get; set; }
        //public DateTime fechaLimite { get; set; }
        public string nombreMembresia { get; set; }

    }
}
