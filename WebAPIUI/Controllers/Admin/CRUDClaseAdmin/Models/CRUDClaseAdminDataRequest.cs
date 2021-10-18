using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.CRUDClaseAdmin.Models
{
    public class CRUDClaseAdminDataRequest
    {
        public int flujoID { get; set; }
        public int claseID { get; set; }
        public string disciplinaID { get; set; } 
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
} 