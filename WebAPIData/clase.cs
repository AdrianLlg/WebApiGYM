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
    
    public partial class clase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public clase()
        {
            this.cronograma = new HashSet<cronograma>();
            this.clase_persona = new HashSet<clase_persona>();
            this.clase_recurso = new HashSet<clase_recurso>();
        }
    
        public int claseID { get; set; }
        public int disciplinaID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cronograma> cronograma { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<clase_persona> clase_persona { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<clase_recurso> clase_recurso { get; set; }
        public virtual disciplina disciplina { get; set; }
    }
}