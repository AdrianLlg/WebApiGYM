using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Models.SalaAdmin
{
    public class SalaAdminModel
    {
        public int salaID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string estadoRegistro { get; set; }

    }
}