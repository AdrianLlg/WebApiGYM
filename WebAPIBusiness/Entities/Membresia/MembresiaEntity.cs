using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIBusiness.Entities.App.MembresiasPersona;
using WebAPIData;

namespace WebAPIBusiness.Entities.Membresia
{
    public class MembresiaEntity
    {
        public int membresia_persona_pagoID { get; set; }
        public int membresiaID { get; set; }
        public string nombreMembresia { get; set; }
        public decimal precioMembresia { get; set; }
        public string periodicidadMembresia { get; set; }
        public DateTime fechaInicioMembresia { get; set; }
        public DateTime fechaFinMembresia { get; set; }
        public string formaPago { get; set; }
        public string nroDocumento { get; set; }
        public string Banco { get; set; }
        public DateTime? fechaPago { get; set; }
        public DateTime fechaLimite { get; set; }
        public string estado { get; set; }

        public string estadoMembresia { get; set; }
        public List<DisciplinasMembresiasPersonaEntity> disciplinasMemb { get; set; }
    }
}
