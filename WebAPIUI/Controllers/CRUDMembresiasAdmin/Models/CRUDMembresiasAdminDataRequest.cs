using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.CRUDMembresiasAdmin.Models
{
    public class CRUDMembresiaAdminDataRequest
    {
        public int flujoID { get; set; }
        public int membresiaID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string precio { get; set; }
    }
}