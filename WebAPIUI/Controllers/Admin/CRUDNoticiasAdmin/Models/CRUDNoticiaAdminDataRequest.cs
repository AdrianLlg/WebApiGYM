using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.CRUDNoticiaAdmin.Models
{
    public class CRUDNoticiaAdminDataRequest
    {
        public int flujoID { get; set; }
        public int noticiaID { get; set; }
        public string titulo { get; set; }
        public string contenido { get; set; }
        public string imagen { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
        public string estado { get; set; }
    }
}