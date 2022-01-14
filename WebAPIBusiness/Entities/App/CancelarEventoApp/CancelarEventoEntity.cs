using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.App.CancelarEventoApp
{
    public class CancelarEventoEntity
    {
        public int eventoID { get; set; }

        public DateTime fechaInicioEvento { get; set; }

        public string horaInicio { get; set; }

    }
}
