using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBusiness.Entities.ConsultaHorarios;

namespace WebAPIUI.Controllers.ConsultaRepEventoSala.Models
{
    public class ConsultaRepEventoSalaDataRequest
    {
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
        
    }
} 