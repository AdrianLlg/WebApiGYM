//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPIData
{
    using System;
    using System.Collections.Generic;
    
    public partial class sol_membresiaPago
    {
        public int sol_membresiaPagoID { get; set; }
        public int personaID { get; set; }
        public int membresiaID { get; set; }
        public int membresia_persona_pagoID { get; set; }
        public System.DateTime fechaRegistroSolicitud { get; set; }
        public byte[] comprobante { get; set; }
        public string estado { get; set; }
    
        public virtual membresia_persona_pago membresia_persona_pago { get; set; }
        public virtual persona persona { get; set; }
        public virtual membresia membresia { get; set; }
    }
}
