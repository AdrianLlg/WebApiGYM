using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.App.ModificacionDatosPersonales.Models
{
    public class ModificacionDatosPersonalesDataRequest
    {
        public int flujoID { get; set; }
        public int personaID { get; set; }
        public string newPassword { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string fechaNacimiento { get; set; }
    }
}