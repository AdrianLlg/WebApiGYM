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
    
    public partial class membresia_persona_disciplina
    {
        public int membresia_persona_disciplinaID { get; set; }
        public int membresiaID { get; set; }
        public int personaID { get; set; }
        public int disciplinaID { get; set; }
        public System.DateTime fechaPago { get; set; }
        public System.DateTime fechaLimite { get; set; }
        public int numClasesDisponibles { get; set; }
        public string statusMembresia { get; set; }
    
        public virtual disciplina disciplina { get; set; }
        public virtual membresia membresia { get; set; }
        public virtual persona persona { get; set; }
    }
}