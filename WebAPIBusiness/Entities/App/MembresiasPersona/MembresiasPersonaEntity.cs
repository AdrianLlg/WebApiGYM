using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.App.MembresiasPersona
{
    public class MembresiasPersonaEntity
    {
        public int membresia_persona_pagoID { get; set; }
        public int personaID { get; set; }
        public int membresiaID { get; set; }
        public System.DateTime fechaInicioMembresia { get; set; }
        public System.DateTime fechaFinMembresia { get; set; }
        public string formaPago { get; set; }
        public Nullable<System.DateTime> fechaTransaccion { get; set; }
        public string nroDocumento { get; set; }
        public string Banco { get; set; }
        public string estado { get; set; }



    }
}
