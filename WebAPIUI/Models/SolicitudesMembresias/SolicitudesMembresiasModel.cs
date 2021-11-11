using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Models.SolicitudesMembresias
{
    public class SolicitudesMembresiasModel
    {
        public int solicitud_membresiaPersonaID { get; set; }

        public int personaID { get; set; }
        public string nombrePersona { get; set; }
        public string identificacionPersona { get; set; }

        public int membresiaID { get; set; }
        public string nombreMembresia { get; set; }
        public string perioridicidadMembresia { get; set; }

        public int membresia_persona_pagoID { get; set; }
        public string fechaRegistroSolicitud { get; set; }
        public string comprobante { get; set; }
    }
}