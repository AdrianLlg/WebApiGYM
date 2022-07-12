using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.CRUDRecursoEspecialAdmin.Models
{
    public class CRUDRecursoEspecialAdminDataRequest
    {
        public int flujoID { get; set; }
        public int recursoEspecialID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string estadoRegistro { get; set; }

    }
}