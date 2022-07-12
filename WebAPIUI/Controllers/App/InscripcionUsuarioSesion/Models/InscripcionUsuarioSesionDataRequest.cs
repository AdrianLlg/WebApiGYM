using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.App.InscripcionUsuarioSesion.Models
{
    public class InscripcionUsuarioSesionDataRequest
    {
        public int personaID { get; set; }

        public int eventoID { get; set; }

        public string estado { get; set; }

        public int recursoAsignado { get; set; }

        public bool recursosEvento { get; set; }

    }
}