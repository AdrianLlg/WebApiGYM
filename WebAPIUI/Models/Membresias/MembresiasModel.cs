using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Models.Membresias
{
    public class MembresiasModel
    {
        public string nombreMembresia { get; set; }
        public decimal precioMembresia { get; set; }

        public string periodicidadMembresia { get; set; }
       // public List<membresia_persona_disciplina> disciplinasmembresia { get; set; }
        public string fechaPago { get; set; }
        public string fechaLimite { get; set; }

    }
}