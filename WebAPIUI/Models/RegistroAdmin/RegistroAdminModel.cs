using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Models.RegistroAdmin
{
    public class RegistroAdminModel
    {
        public int personaID { get; set; }
        public int rolePID { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string identificacion { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string edad { get; set; }
        public string sexo { get; set; }
        public string fechaNacimiento { get; set; }
        public string fechaCreacion { get; set; }
        public string estado { get; set; }

    }
}