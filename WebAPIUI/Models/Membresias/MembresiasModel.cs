using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        // public List<membresia_persona_disciplina> disciplinasmembresia { get; set; }
        public string fechaPago { get; set; }
        public string fechaLimite { get; set; }
        public string estado { get; set; }

    }
}