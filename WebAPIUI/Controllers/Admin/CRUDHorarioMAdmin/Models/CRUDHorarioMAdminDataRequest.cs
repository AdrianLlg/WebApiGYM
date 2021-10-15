using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.CRUDSHorarioMAdmin.Models
{
    public class CRUDHorarioMAdminDataRequest
    {
        public int flujoID { get; set; }
        public int horarioMID { get; set; }
        public string horaInicio { get; set; }
        public string horaFin { get; set; }
    }
} 