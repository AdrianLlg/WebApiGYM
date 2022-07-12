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

        public string fechaInicioMembresia { get; set; }
        public string formaPago { get; set; }
        public string fechaTransaccion {get; set; }
        public string nroDocumento     {get; set; }
        public string Banco { get; set; }
    }
}