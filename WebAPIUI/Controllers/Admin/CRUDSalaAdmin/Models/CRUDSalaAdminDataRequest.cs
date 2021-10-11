using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.CRUDSalaAdmin.Models
{
    public class CRUDSalaAdminDataRequest
    {
        public int flujoID { get; set; }
        public int salaID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
}