using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Models.Membresias
{
    public class MembresiasModel
    {
        public int disciplinaID { get; set; }
        public string nombreDisciplina { get; set; }
        public decimal precio { get; set; }
        public int numClasesDisponibles { get; set; }
        public string fechaPago { get; set; }
        public string fechaLimite { get; set; }
        public string nombreMembresia { get; set; }

    }
}