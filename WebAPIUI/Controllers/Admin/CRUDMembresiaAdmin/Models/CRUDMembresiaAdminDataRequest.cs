using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIUI.Controllers.Admin.CRUDMembresiaAdmin.Models;

namespace WebAPIUI.Controllers.CRUDMembresiaAdmin.Models
{
    public class CRUDMembresiaAdminDataRequest
    {
        public int flujoID { get; set; }
        public int membresiaID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string precio { get; set; }
        public string periodicidad { get; set; }
        
        public List<DisciplinasMembresiaModel> disciplinas { get; set; }
    }
}