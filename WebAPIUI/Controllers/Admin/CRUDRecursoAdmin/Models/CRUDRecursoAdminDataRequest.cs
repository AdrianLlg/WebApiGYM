using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.CRUDRecursoAdmin.Models
{
    public class CRUDRecursoAdminDataRequest
    {
        public int flujoID { get; set; }
        public int recursoID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string cantidadRecurso { get; set; }
    }
}