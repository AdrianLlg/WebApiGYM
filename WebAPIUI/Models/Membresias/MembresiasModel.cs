using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBusiness.Entities.App.MembresiasPersona;

namespace WebAPIUI.Models.Membresias
{
    public class MembresiasModel
    {
        public int membresia_persona_pagoID { get; set; }
        public int membresiaID { get; set; }
        public string nombreMembresia { get; set; }
        public decimal precioMembresia { get; set; }
        public string periodicidadMembresia { get; set; }
        public string fechaInicioMembresia { get; set; }
        public string fechaFinMembresia { get; set; }
        public string formaPago { get; set; }
        public string nroDocumento { get; set; }
        public string Banco { get; set; }
        public string fechaPago { get; set; }
        public string fechaLimite { get; set; }
        public string estado { get; set; }
        public string estadoMembresia { get; set; }
        public List<DisciplinasMembresiasPersonaEntity> disciplinasMemb { get; set; }

    }
}