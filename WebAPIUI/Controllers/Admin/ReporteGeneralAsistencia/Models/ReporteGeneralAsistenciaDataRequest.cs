using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBusiness.Entities.ConsultaHorarios;

namespace WebAPIUI.Controllers.ReporteGeneralAsistencia.Models
{
    public class ReporteGeneralAsistenciaDataRequest
    {
        public int personaID { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }

    }
}