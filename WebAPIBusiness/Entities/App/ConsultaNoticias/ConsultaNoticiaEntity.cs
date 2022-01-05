using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.App.ConsultaNoticias

{
    public class ConsultaNoticiaEntity
    {
        public int noticiaID { get; set; }
        public string titulo { get; set; }
        public string contenido { get; set; }
        public string imagen { get; set; }
        public DateTime fechaInicio{ get; set; } 
        public DateTime fechaFin { get; set; }
        public string estadoRegistro { get; set; } 
    }
}
