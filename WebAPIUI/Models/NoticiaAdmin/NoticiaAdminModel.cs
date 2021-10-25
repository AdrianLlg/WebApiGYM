using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Models.NoticiaAdmin
{
    public class NoticiaAdminModel
    {
        public int noticiaID { get; set; }
        public string titulo { get; set; }
        public string contenido { get; set; }
        public string imagen { get; set; }
        public string fechaInicio { get; set; } 
        public string fechaFin { get; set; }   
    }
}
