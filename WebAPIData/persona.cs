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
    
    public partial class persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public persona()
        {
            this.fichaEntrenamiento = new HashSet<fichaEntrenamiento>();
            this.fichaPersona = new HashSet<fichaPersona>();
            this.membresia_persona_disciplina = new HashSet<membresia_persona_disciplina>();
            this.membresia_persona_pago = new HashSet<membresia_persona_pago>();
            this.sol_membresiaPago = new HashSet<sol_membresiaPago>();
            this.usuario = new HashSet<usuario>();
            this.evento = new HashSet<evento>();
            this.evento_persona = new HashSet<evento_persona>();
        }
    
        public int personaID { get; set; }
        public int rolePID { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string identificacion { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string edad { get; set; }
        public string sexo { get; set; }
        public System.DateTime fechaNacimiento { get; set; }
        public System.DateTime fechaCreacion { get; set; }
        public string estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fichaEntrenamiento> fichaEntrenamiento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fichaPersona> fichaPersona { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<membresia_persona_disciplina> membresia_persona_disciplina { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<membresia_persona_pago> membresia_persona_pago { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sol_membresiaPago> sol_membresiaPago { get; set; }
        public virtual roleP roleP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario> usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<evento> evento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<evento_persona> evento_persona { get; set; }
    }
}
