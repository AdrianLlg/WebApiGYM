using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Models.SalaRecursoEspecial
{
    public class SalaRecursoEspecialModel
    {
        public int salaRecursoEspecialID { get; set; }
        public int salaID { get; set; }
        public int recursoEspecialID { get; set; }
        public string estadoRegistro { get; set; }
    }
}