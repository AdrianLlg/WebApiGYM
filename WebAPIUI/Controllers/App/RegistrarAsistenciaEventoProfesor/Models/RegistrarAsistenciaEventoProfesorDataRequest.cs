using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBusiness.Entities.ConsultaHorarios;

namespace WebAPIUI.Controllers.App.RegistrarAsistenciaEventoProfesor.Models
{
    public class RegistrarAsistenciaEventoProfesorDataRequest
    {
        public int eventoID { get; set; }
        public int personaID { get; set; }
         
    }
} 