using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBusiness.Entities.ConsultaHorarios;

namespace WebAPIUI.Controllers.ConsultaHorarios.Models
{
    public class ConsultaHorariosDataRequest
    {
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
        public List<SalaEntity> Salas { get; set; }

        public int personaID { get; set; }
    }
} 