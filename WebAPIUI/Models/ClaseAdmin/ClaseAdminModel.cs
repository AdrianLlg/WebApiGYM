using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Models.ClaseAdmin
{
    public class ClaseAdminModel
    {
        public int claseID { get; set; }
        public int disciplinaID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string estadoRegistro { get; set; }
    }
}