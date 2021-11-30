using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.CRUDFichaEntrenamiento.Models
{
    public class FichaEntrenamientoDataRequest
    {
        public int flujoID { get; set; }
        public int fichaEntrenamientoID { get; set; }
        public string FechaCreacion { get; set; }
        public int fichaPersonaID { get; set; }
        public int ProfesorID { get; set; }
        public int DiciplinaID { get; set; }
        public string Observaciones { get; set; }
    }
}