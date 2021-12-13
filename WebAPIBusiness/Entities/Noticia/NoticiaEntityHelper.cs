using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.Noticia

{
    public class NoticiaEntityHelper
    {
        public int noticiaID { get; set; }
        public string titulo { get; set; }
        public string contenido { get; set; }
        public byte[] imagen { get; set; }
        public DateTime fechaInicio{ get; set; } 
        public DateTime fechaFin { get; set; }
        public string estadoRegistro { get; set; } 
    }
}
