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
    
    public partial class evento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public evento()
        {
            this.evento_persona = new HashSet<evento_persona>();
        }
    
        public int eventoID { get; set; }
        public int claseID { get; set; }
        public int horarioMID { get; set; }
        public System.DateTime fecha { get; set; }
        public int salaID { get; set; }
        public int aforoMax { get; set; }
        public int aforoMin { get; set; }
        public int personaID { get; set; }
        public string estadoRegistro { get; set; }
    
        public virtual clase clase { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<evento_persona> evento_persona { get; set; }
        public virtual horarioM horarioM { get; set; }
        public virtual persona persona { get; set; }
        public virtual sala sala { get; set; }
    }
}
