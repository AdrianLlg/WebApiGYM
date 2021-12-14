using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.CRUDSalaRecurso.Models
{
    public class CRUDSalaRecursoDataRequest
    {
        public int flujoID { get; set; }
        public int salaRecursoID { get; set; }
        public int salaID { get; set; }
        public string nombreRecurso { get; set; }
        public int cantidad { get; set; }
        public string estadoRegistro { get; set; }
    }

}
