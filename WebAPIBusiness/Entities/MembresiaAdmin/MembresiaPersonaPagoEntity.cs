using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.MembresiaAdmin
{
    public class MembresiaPersonaPagoEntity
    {
        public int membresia_persona_pagoID { get; set; }
        public int personaID { get; set; }
        public int membresiaID { get; set; }
        public System.DateTime fechaInicioMembresia { get; set; }
        public System.DateTime fechaFinMembresia { get; set; }
        public byte[] comprobante { get; set; }
        public string estado { get; set; }

    }
}
