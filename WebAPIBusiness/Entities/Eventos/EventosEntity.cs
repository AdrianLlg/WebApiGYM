using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.Eventos
{
    public class EventosEntity
    {
        public int claseID { get; set; }
        public int horarioMID { get; set; }
        public DateTime fecha { get; set; }
        public int eventoID { get; set; }
        public int salaID { get; set; }
        public int aforoMax { get; set; }
        public int aforoMin { get; set; }
    }
}
