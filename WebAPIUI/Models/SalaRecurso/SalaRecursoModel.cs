using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Models.SalaRecurso
{
    public class SalaRecursoModel
    {
        public int salaRecursoID { get; set; }
        public int salaID { get; set; }
        public string nombreRecurso { get; set; }
        public int cantidad { get; set; }
        public string estadoRegistro { get; set; }
    }
}