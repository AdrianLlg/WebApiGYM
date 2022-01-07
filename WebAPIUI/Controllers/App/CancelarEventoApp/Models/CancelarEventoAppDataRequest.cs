using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.CancelarEventoApp.Models
{
    public class CancelarEventoAppDataRequest
    {
        public int eventoID { get; set; }
        public string motivo { get; set; }
        public string posibleHorarioRecuperacion { get; set; }


    }
}