using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.HorasDisciplinaFechaEntity
{
    public class HorasDisciplinaFechaEntity
    {
        public int CronoID { get; set; }
        public int Clase { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string fecha { get; set; }
        public string horaInicio { get; set; }
        public string horaFin { get; set; }
        public string Asistentes { get; set; }
        public string REG { get; set; }

    }
}
