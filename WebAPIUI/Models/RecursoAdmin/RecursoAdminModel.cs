using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Models.RecursoAdmin
{
    public class RecursoAdminModel
    {
        public int RecursoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string CantidadDeRecurso { get; set; }

    }
}