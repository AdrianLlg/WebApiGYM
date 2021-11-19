using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.SolicitudesMembresias.Models
{
    public class SolicitudesMembresiasDataRequest
    {
        public int flujoID { get; set; }
        public int solicitud_membresiaPagoID { get; set; }
        public int membresia_persona_pagoID { get; set; }

        //0 = Borrar solicitud y 1 = Aceptó la solicitud
        public int IdentificadorAceptarEliminar { get; set; }
        public string formaPago { get; set; }
        public string fechaTransaccion { get; set; }
        public string nroDocumento { get; set; }
        public string Banco { get; set; }
    }
}