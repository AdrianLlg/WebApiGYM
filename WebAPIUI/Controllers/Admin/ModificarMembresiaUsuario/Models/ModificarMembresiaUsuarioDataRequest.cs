using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.ModificarMembresiaUsuario.Models
{
    public class ModificarMembresiaUsuarioDataRequest
    {
        public int membresia_persona_pagoID { get; set; }       
        public string fechaInicioMembresia { get; set; }
        public string fechaFinMembresia { get; set; }
        public string formaPago { get; set; }
        public string nroDocumento { get; set; }
        public string Banco { get; set; }
        public string fechaPago { get; set; }
    }
}