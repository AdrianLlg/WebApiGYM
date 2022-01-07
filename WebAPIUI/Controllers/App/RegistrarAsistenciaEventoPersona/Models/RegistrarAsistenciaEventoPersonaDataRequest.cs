using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBusiness.Entities.ConsultaHorarios;

namespace WebAPIUI.Controllers.App.RegistrarAsistenciaEventoPersona.Models
{
    public class RegistrarAsistenciaEventoPersonaDataRequest
    {
        public int eventoID { get; set; }
        public int personaID { get; set; }
         
    }
} 