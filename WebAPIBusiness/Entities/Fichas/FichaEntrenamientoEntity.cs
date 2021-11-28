using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.Fichas
{
    public class FichaEntrenamientoEntity
    {
        public int fichaEntrenamientoID { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int fichaPersonaID { get; set; }
        public int ProfesorID { get; set; }
        public int DiciplinaID { get; set; }
        public string Observaciones { get; set; }
         

    }
}
