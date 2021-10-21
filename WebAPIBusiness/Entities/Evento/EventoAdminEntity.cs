using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.EventoAdmin
{
    public class EventoAdminEntity
    {
        public int eventoID { get; set; }
        public string claseID { get; set; }
        public string horarioMID { get; set; }
        public string fecha { get; set; }
        public string salaID { get; set; }
        public string aforoMax { get; set; }
        public string aforoMin { get; set; }

    }
}
