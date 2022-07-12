using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.ConsultaMailCancelacion
{
    public class ConsultaMailCancelacionEntity
    {

        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string clase { get; set; }
        public DateTime fecha { get; set; } 
        public string horario { get; set; }

    }
}
