using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Models.ConsultaNoticias
{
    public class ConsultaNoticiasModel
    {
        public int noticiaID { get; set; }
        public string titulo { get; set; }
        public string contenido { get; set; }
        public string imagen { get; set; }
        public string fechaInicio { get; set; } 
        public string fechaFin { get; set; }
        public string estadoRegistro { get; set; }
    }
}
