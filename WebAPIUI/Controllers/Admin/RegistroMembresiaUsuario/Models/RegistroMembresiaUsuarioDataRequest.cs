using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.RegistroMembresiaUsuario.Models
{
    public class RegistroMembresiaUsuarioDataRequest
    {
        public int personaID { get; set; }

        public int membresiaID { get; set; }

        public string fechaPago { get; set; }
    }
}