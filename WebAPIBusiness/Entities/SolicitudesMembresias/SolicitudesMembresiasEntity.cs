using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.SolicitudesMembresias
{
    public class SolicitudesMembresiasEntity
    {
        public int solicitud_membresiaPagoID { get; set; }        

        public int personaID { get; set; }
        public string nombrePersona { get; set; }
        public string identificacionPersona { get; set; }

        public int membresiaID { get; set; }
        public string nombreMembresia { get; set; }
        public string perioridicidadMembresia { get; set; }

        public int membresia_persona_pagoID { get; set; }
        public System.DateTime fechaRegistroSolicitud { get; set; }
        public byte[] comprobante { get; set; }
        public string estado { get; set; }

    }
}
