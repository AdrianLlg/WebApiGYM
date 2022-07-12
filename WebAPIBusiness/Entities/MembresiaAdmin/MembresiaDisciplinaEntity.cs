using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIData;

namespace WebAPIBusiness.Entities.MembresiaAdmin
{
    public class MembresiaDisciplinaEntity
    {
        public int membresia_disciplinaID { get; set; }
        public int membresiaID { get; set; }
        public int disciplinaID { get; set; }
        public int numClasesDisponibles { get; set; }
    }
}
