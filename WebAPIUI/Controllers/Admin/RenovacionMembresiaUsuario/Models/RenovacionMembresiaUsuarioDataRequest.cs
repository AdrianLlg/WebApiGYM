using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.RenovacionMembresiaUsuario.Models
{
    public class RenovacionMembresiaUsuarioDataRequest
    {
        public int personaID { get; set; }

        public int membresiaID { get; set; }
        public string imagen { get; set; }
    }
}