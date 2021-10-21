using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIData;

namespace WebAPIBusiness.Entities.MembresiaAdmin
{
    public class MembresiaPersonaDisciplinaEntity
    {
        public int membresia_persona_disciplinaID { get; set; }
        public int membresiaID { get; set; }
        public int personaID { get; set; }
        public DateTime fechaPago { get; set; }
        public DateTime fechaLimite { get; set; }
        public string statusMembresia { get; set; }

    }
}
