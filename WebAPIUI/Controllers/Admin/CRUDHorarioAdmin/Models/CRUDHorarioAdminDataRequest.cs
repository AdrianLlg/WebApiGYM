using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.CRUDHorarioAdmin.Models
{
    public class CRUDHorarioAdminDataRequest
    {
        public int flujoID { get; set; }
        public int HorarioID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
} 